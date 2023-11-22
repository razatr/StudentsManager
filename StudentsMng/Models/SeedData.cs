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

        InitGroups(context);
        await context.SaveChangesAsync();

        InitStudents(context, context.StudentsGroups.Local.ToList());
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
                StudentsGroupId = Groups[rnd.Next(Groups.Count)].Id,
            },
            new Student
            {
                LastName = "Хайруллин",
                Name = "Тахир",
                Patronymic = "Рамилевич",
                StudentsGroupId = Groups[rnd.Next(Groups.Count)].Id,
            },
            new Student
            {
                LastName = "Казютин",
                Name = "Илья",
                Patronymic = "Алексеевич",
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

        context.StudentsGroups.Add(new StudentsGroup
        {
            Name = "НМТмд-01-22",
            Description = "Лучшая группа ФФМиЕН!"
        });
    }
}
