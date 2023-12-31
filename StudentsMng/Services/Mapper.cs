﻿using StudentsManager.DAL.Entities;
using StudentsManager.ViewModels;
using StudentsManager.ViewModels.Schedule;

namespace StudentsManager.Services;

public class Mapper
{
    public static StudentViewModel Convert(Student stud)
    {
        return stud is null ?
            new StudentViewModel()
            : new StudentViewModel
            {
                Id = stud.Id,
                Name = stud.Name,
                LastName = stud.LastName,
                Patronymic = stud.Patronymic,
                GroupId = stud.StudentsGroupId,
            };
    }

    public static Student Convert(StudentViewModel studView)
    {
        return new Student
        {
            Id = studView.Id,
            LastName = studView.LastName,
            Name = studView.Name,
            Patronymic = studView.Patronymic,
            StudentsGroupId = studView.GroupId,
        };
    }


    public static StudentsGroupViewModel Convert(StudentsGroup group, Student[] students)
    {
        return new StudentsGroupViewModel
            {
                Id = group.Id,
                Name = group.Name ?? "Безымянная",
                Description = group.Description ?? "Без описания",
                StudentsList = students.Select(Convert).ToArray()
            };
    }

    public static GroupElementViewModel Convert(StudentsGroup group, bool selected)
    {
        return new GroupElementViewModel
        {
            Id = group.Id,
            Name = group.Name,
            Selected = selected
        };
    }

    public static StudentsGroup Convert(StudentsGroupViewModel groupView)
    {
        var studentsList = groupView.StudentsList is null ?
            new HashSet<Student>()
            : groupView.StudentsList.Select(Convert).ToHashSet();

        var group = new StudentsGroup
        {
            Id = groupView.Id,
            Name = groupView.Name,
            Description = groupView.Description,
            Students = studentsList
        };

        return group;
    }


    public static DayScheduleViewModel Convert(DayOfWeek day, ScheduleEntity[] courses)
    {
        return new DayScheduleViewModel
        {
            Day = day.ToString(),
            Courses = courses
                .Select(Convert)
                .ToArray()
        };
    }

    public static CourseViewModel? Convert(ScheduleEntity schedule)
    {
        return schedule.Course is null ? null
            : new CourseViewModel
            {
                Id = schedule.Course.Id,
                Name = schedule.Course.Name,
                Description = schedule.Course.Description,
            };
    }
}
