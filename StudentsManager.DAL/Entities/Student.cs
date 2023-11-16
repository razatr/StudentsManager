using StudentsManager.DAL.Entities.Base;

namespace StudentsManager.DAL.Entities
{
    public class Student : NamedEntity
    {
        public string LastName { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
    }
}
