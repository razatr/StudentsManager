using StudentsManager.DAL.Context;
using StudentsManager.DAL.Entities;
using StudentsManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Services;

public class DbScheduleData: IScheduleData
{
    private readonly StudentsDB _db;
    public DbScheduleData(StudentsDB db)
    {
        _db = db;
    }
    public Course? GetCourse(int groupId, DayOfWeek day, int orderOfCourse)
    {
        ScheduleEntity? foundedScheduleEntity = _db.Schedule.FirstOrDefault(scheduleEntity =>
            scheduleEntity.GroupId == groupId &&
            scheduleEntity.Day == day &&
            scheduleEntity.OrderOfDay == orderOfCourse
        );
        if ( foundedScheduleEntity == null )
        {
            return null;
        } else { 
            return foundedScheduleEntity.Course; 
        }
    }
    public Course?[] GetCoursesForDay(int groupId, DayOfWeek day)
    {
        return Enumerable
            .Range(1, 7)
            .Select(order => GetCourse(groupId, day, order))
            .ToArray();
    }
}

