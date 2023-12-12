using StudentsManager.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsManager.DAL.Entities;

public class Student : NamedEntity
{
    public string LastName { get; set; } = string.Empty;

    public string Patronymic { get; set; } = string.Empty;

    public int StudentsGroupId { get; set; }
}
