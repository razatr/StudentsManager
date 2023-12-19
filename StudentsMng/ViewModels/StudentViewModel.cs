using StudentsManager.DAL.Entities.Base;

namespace StudentsManager.ViewModels;

public class StudentViewModel : NamedEntity
{
    public string LastName { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public int GroupId { get; set; }

    public string FullName { get => $"{LastName} {Name} {Patronymic}"; }
}