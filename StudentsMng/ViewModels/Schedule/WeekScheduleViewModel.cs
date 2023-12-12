namespace StudentsManager.ViewModels.Schedule;

public class WeekScheduleViewModel
{
    public int GroupId { get; set; }
    public required string GroupName { get; set; }
    public DayScheduleViewModel[] Schedule { get; set; } = new DayScheduleViewModel[7];
}
