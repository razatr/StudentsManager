namespace StudentsManager.DAL.Entities.Base;

public abstract class NamedEntity : Entity
{
    public string Name { get; set; } = string.Empty;
}
