using Microsoft.EntityFrameworkCore;
using StudentsManager.DAL.Context;
using StudentsManager.DAL.Entities;

namespace StudentManager.Models;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new StudentsDB(
            serviceProvider.GetRequiredService<
                DbContextOptions<StudentsDB>>()))
        {
            // Look for any Students.
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }
            context.Students.AddRange(
                new Student
                {
                    Name = "Азат",
                    LastName = "Рашидов",
                    Patronymic = "Раушанович"
                },
                new Student
                {
                    Name = "Тахир",
                    LastName = "Хайруллин",
                    Patronymic = "Рамилевич"
                },
                new Student
                {
                    Name = "Илья",
                    LastName = "Казютин",
                    Patronymic = "Алексеевич"
                },
                new Student
                {
                    Name = "Павел",
                    LastName = "Шмачилин",
                    Patronymic = "Александрович"
                }
            );
            await context.SaveChangesAsync();
        }
    }
}
