using StudentsManager.DAL.Entities.Base;
namespace StudentsManager.DAL.Entities;

public class StudentsGroup: NamedEntity
{
    public string? Description { get; set; }
    public List<Student> StudentsList { get; set; } = new List<Student>();
}
