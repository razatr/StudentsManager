using StudentsManager.DAL.Entities.Base;
using StudentsManager.DAL.Entities;

namespace StudentsManager.ViewModels;

public class StudentViewModel : NamedEntity
{
    public string LastName { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public int GroupId { get; set; }

    public string FullName { get => $"{LastName} {Name} {Patronymic}"; }

    public StudentViewModel() 
    { }

    public StudentViewModel(Student stud)
    {
        Id = stud.Id;
        Name = stud.Name;
        LastName = stud.LastName;
        Patronymic = stud.Patronymic;
        GroupId = stud.StudentsGroupId;
    }
}