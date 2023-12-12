using StudentsManager.DAL.Entities.Base;

namespace StudentsManager.ViewModels.Schedule;

public class CourseViewModel : NamedEntity
{
    public string Description { get; set; } = string.Empty;
}
