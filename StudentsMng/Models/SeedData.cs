using Microsoft.EntityFrameworkCore;
using StudentsManager.DAL.Context;
using StudentsManager.DAL.Entities;

namespace StudentsManager.Models;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using var context = new StudentsDB(
            serviceProvider.GetRequiredService<
                    DbContextOptions<StudentsDB>>());
        
        // Look for any Students.
        await context.Database.EnsureCreatedAsync();
        if (context.Students.Any())
        {
            return;   // DB has been seeded
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
        await context.SaveChangesAsync();
    }
}
