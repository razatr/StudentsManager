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
        StudentsList = group.Students
            .Select(stud => new StudentViewModel(stud))
            .ToArray();
    }

    public void Deconstruct(out int Id, out string Name) => (Id, Name) = (this.Id, this.Name);
}
