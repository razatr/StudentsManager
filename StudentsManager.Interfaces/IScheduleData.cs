using StudentsManager.DAL.Entities;

namespace StudentsManager.Interfaces;

public interface IScheduleData
{
    ScheduleEntity GetCourse(int groupId, DayOfWeek day, int orderOfCourse);

    ScheduleEntity[] GetCoursesForDay(int groupId, DayOfWeek day)
    {
        return Enumerable
            .Range(1, 7)
            .Select(order => GetCourse(groupId, day, order))
            .ToArray();
    }
}
