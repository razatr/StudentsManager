using StudentsManager.DAL.Entities.Base;
namespace StudentsManager.DAL.Entities;

public class Course : NamedEntity
{
    public string Description { get; set; } = string.Empty;
    public List<StudentsGroup> Groups { get; set; } = new List<StudentsGroup>();
}
