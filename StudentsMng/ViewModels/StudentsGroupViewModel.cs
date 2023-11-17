using StudentsManager.DAL.Entities;
using StudentsManager.DAL.Entities.Base;
namespace StudentsManager.ViewModels;

public class StudentsGroupViewModel : NamedEntity
{
    public string? Description { get; set; }
    public Student[]? StudentsList { get; set; }

    public StudentsGroupViewModel() { }

    public StudentsGroupViewModel(StudentsGroup group)
    {
        Description = group.Description;
        StudentsList = group.StudentsList.ToArray();
    }
}
