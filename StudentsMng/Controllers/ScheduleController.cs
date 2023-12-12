using Microsoft.AspNetCore.Mvc;
using StudentsManager.Interfaces;
using StudentsManager.Services;
using StudentsManager.ViewModels.Schedule;

namespace StudentsManager.Controllers;

public class ScheduleController : Controller
{
    private readonly IScheduleData _ScheduleManager;
    private readonly IStudentsGroupData _StudentsGroupManager;
    public ScheduleController(IScheduleData scheduleManager, IStudentsGroupData studentsGroupManager)
    {
        _ScheduleManager = scheduleManager;
        _StudentsGroupManager = studentsGroupManager;
    }

    public IActionResult Index(int groupId)
    {
        var days = new DayOfWeek[] {
            DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
            DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday
        };
        var group = _StudentsGroupManager.GetById(groupId);
        var scheduleView = new WeekScheduleViewModel
        {
            GroupId = group.Id,
            GroupName = group.Name,
            Schedule = days
                .Select(day => {
                    var courses = _ScheduleManager.GetCoursesForDay(group.Id, day);
                    return Mapper.Convert(day, courses);
                })
                .ToArray()
        };

        return View(scheduleView);
    }
}
