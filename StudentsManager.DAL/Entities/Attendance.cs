using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentsManager.DAL.Entities
{
    [PrimaryKey(nameof(StudentId), nameof(DayString), nameof(OrderOfDay))]
    public class Attendance
    {
        public int StudentId { get; set; }
        [NotMapped]
        public DateOnly Day { get; set; }
        public string DayString
        {
            get
            {
                return Day.ToString();
            }
            set
            {
                Day = DateOnly.Parse(value);
            }
        }
        [Range(1, 7)]
        public int OrderOfDay { get; set; }
        public bool AttendanceState { get; set; } = false;
    }
}
