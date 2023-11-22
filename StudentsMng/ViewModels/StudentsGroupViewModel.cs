using StudentsManager.DAL.Entities;
using StudentsManager.DAL.Entities.Base;
namespace StudentsManager.ViewModels;

public class StudentsGroupViewModel : NamedEntity
{
    public string Description { get; set; } = "Без описания";
    public StudentViewModel[]? StudentsList { get; set; }

    public StudentsGroupViewModel() { }

    public StudentsGroupViewModel(StudentsGroup group)
    {
        Description = group.Description ?? "Без описания";
        StudentsList = group.StudentsList
            .Select(stud => new StudentViewModel(stud))
            .ToArray();
    }
}
