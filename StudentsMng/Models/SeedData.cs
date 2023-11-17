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
        
        InitStudents(context);
        InitGroups(context);

        await context.SaveChangesAsync();
    }

    private static void InitStudents(StudentsDB context)
    {
        if (context.Students.Any())
        {
            return;
        }

        context.Students.AddRange(
            new Student
            {
                LastName = "Рашидов",
                Name = "Азат",
                Patronymic = "Раушанович"
            },
            new Student
            {
                LastName = "Хайруллин",
                Name = "Тахир",
                Patronymic = "Рамилевич"
            },
            new Student
            {
                LastName = "Казютин",
                Name = "Илья",
                Patronymic = "Алексеевич"
            },
            new Student
            {
                LastName = "Шмачилин",
                Name = "Павел",
                Patronymic = "Александрович"
            }
        );
    }

    private static void InitGroups(StudentsDB context)
    {
        // TODO!!!
    }
}
