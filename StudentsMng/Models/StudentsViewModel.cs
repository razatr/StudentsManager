using StudentsManager.DAL.Entities.Base;
using StudentsManager.DAL.Entities;

namespace StudentsManager.Models
{
    public class StudentsViewModel : NamedEntity
    {
        public string LastName { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;

        public StudentsViewModel() { }

        public StudentsViewModel(Student stud)
        {
            Id = stud.Id;
            Name = stud.Name;
            LastName = stud.LastName;
            Patronymic = stud.Patronymic;
        }
    }
}