using StudentsManager.DAL.Entities.Base;
namespace StudentsManager.DAL.Entities;

public class StudentsGroup: NamedEntity
{
    public string? Description { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
