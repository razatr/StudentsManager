using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsManager.DAL.Entities
{
    [PrimaryKey(nameof(GroupId), nameof(DayString), nameof(OrderOfDay))]
    public class ScheduleEntity
    {
        public int GroupId { get; set; }
        [NotMapped]
        public DayOfWeek Day { get; set; }
        public string DayString {
            get
            {
                return Day.ToString();
            }
            set 
            {
                Dictionary<string, DayOfWeek> dayOfWeek = new Dictionary<string, DayOfWeek>()
                    {
                        { "Monday", DayOfWeek.Monday },
                        { "Tuesday", DayOfWeek.Tuesday},
                        { "Wednesday" , DayOfWeek.Wednesday},
                        { "Thursday" , DayOfWeek.Thursday},
                        { "Friday" , DayOfWeek.Friday},
                        { "Saturday" , DayOfWeek.Saturday},
                        { "Sunday" , DayOfWeek.Sunday}
                    };
                Day = dayOfWeek[value];
            } 
        }
        [Range(1, 7)]
        public int OrderOfDay { get; set; }
        public Course? Course { get; set; }

    }
}
