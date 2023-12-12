using StudentsManager.DAL.Entities.Base;

namespace StudentsManager.ViewModels;

public class StudentsGroupViewModel : NamedEntity
{
    public string Description { get; set; } = "Без описания";
    public StudentViewModel[] StudentsList { get; set; } = Array.Empty<StudentViewModel>();
}
