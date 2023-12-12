namespace StudentsManager.ViewModels.Schedule;

public class DayScheduleViewModel
{
    public string Day { get; set; } = string.Empty;
    public CourseViewModel?[] Courses { get; set; } = new CourseViewModel[7];
}
