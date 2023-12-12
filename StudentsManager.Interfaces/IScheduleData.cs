using StudentsManager.DAL.Entities;

namespace StudentsManager.Interfaces;

public interface IScheduleData
{
    Course? GetCourse(int groupId, DayOfWeek day, int orderOfCourse);

    Course?[] GetCoursesForDay(int groupId, DayOfWeek day);
}
