using StudentsManager.DAL.Context;
using StudentsManager.DAL.Entities;

namespace StudentsManager.Models;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<StudentsDB>();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        InitCourses(context);
        await context.SaveChangesAsync();
        InitGroups(context);
        await context.SaveChangesAsync();
        InitStudents(context, context.StudentsGroups.Local.ToList());
        await context.SaveChangesAsync();
        InitSchedule(context, context.Courses.Local.ToList());
        await context.SaveChangesAsync();
        InitAttendances(context);
        await context.SaveChangesAsync();
    }

    private static void InitStudents(StudentsDB context, IList<StudentsGroup> Groups)
    {
        if (context.Students.Any())
        {
            return;
        }

        var rnd = new Random(17);

        context.Students.AddRange(
            new Student
            {
                LastName = "Рашидов",
                Name = "Азат",
                Patronymic = "Раушанович",
                StudentsGroupId = 1,
            },
            new Student
            {
                LastName = "Хайруллин",
                Name = "Тахир",
                Patronymic = "Рамилевич",
                StudentsGroupId = 1,
            },
            new Student
            {
                LastName = "Казютин",
                Name = "Илья",
                Patronymic = "Алексеевич",
                StudentsGroupId = 1,
            },
            new Student
            {
                LastName = "Какой-то",
                Name = "Чел",
                Patronymic = "Челович",
                StudentsGroupId = Groups[rnd.Next(Groups.Count)].Id,
            }
        );
    }

    private static void InitGroups(StudentsDB context)
    {
        if (context.StudentsGroups.Any())
        {
            return;
        }

        context.StudentsGroups.AddRange(
            new StudentsGroup
            {
                Name = "НМТмд-01-22",
                Description = "Лучшая группа ФФМиЕН!"
            },
            new StudentsGroup
            {
                Name = "НМТмд-01-21",
                Description = "Это кто?"
            },
            new StudentsGroup
            {
                Name = "НМТмд-01-20",
                Description = "А это?"
            }
        );
    }

    private static void InitCourses(StudentsDB context)
    {
        if (context.Courses.Any())
        {
            return;
        }
        context.Courses.AddRange(
            new Course
            {
                Description = "Матан"
            },
            new Course
            {
                Description = "Албебра"
            },
            new Course
            {
                Description = "Аналитическая геометрия"
            },
            new Course
            {
                Description = "Топология"
            }
        );
    }

    private static void InitSchedule(StudentsDB context, IList<Course> Courses)
    {
        if (context.Schedule.Any())
        {
            return;
        }

        context.Schedule.AddRange(
            new ScheduleEntity
            {
                GroupId = 0,
                Day = DayOfWeek.Monday,
                OrderOfDay = 1,
                Course = Courses[0]
            },
            new ScheduleEntity
            {
                GroupId = 0,
                Day = DayOfWeek.Tuesday,
                OrderOfDay = 1,
                Course = Courses[2]
            },
            new ScheduleEntity
            {
                GroupId = 0,
                Day = DayOfWeek.Tuesday,
                OrderOfDay = 2,
                Course = Courses[1]
            },
            new ScheduleEntity
            {
                GroupId = 1,
                Day = DayOfWeek.Monday,
                OrderOfDay = 3,
                Course = Courses[2]
            },
            new ScheduleEntity
            {
                GroupId = 2,
                Day = DayOfWeek.Friday,
                OrderOfDay = 1,
                Course = Courses[0]
            }
        );
    }

    private static void InitAttendances(StudentsDB context)
    {
        if (context.Attendances.Any())
        {
            return;
        }
        context.Attendances.AddRange(
            new Attendance
            {
                StudentId = 0,
                Day = new DateOnly(2023, 9, 4),
                OrderOfDay = 1,
                AttendanceState = true
            },
            new Attendance
            {
                StudentId = 1,
                Day = new DateOnly(2023, 9, 4),
                OrderOfDay = 1,
                AttendanceState = true
            },
            new Attendance
            {
                StudentId = 2,
                Day = new DateOnly(2023, 9, 4),
                OrderOfDay = 1,
                AttendanceState = true
            },
            new Attendance
            {
                StudentId = 3,
                Day = new DateOnly(2023, 9, 8),
                OrderOfDay = 1,
                AttendanceState = true
            }
        );
    }
}
