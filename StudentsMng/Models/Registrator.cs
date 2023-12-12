using StudentsManager.AutoMappers;
using StudentsManager.Interfaces;
using StudentsManager.Services;

namespace StudentsManager.Models;

internal static class Registrator
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentsData, DbStudentsData>();
        services.AddScoped<IStudentsGroupData, DbStudentsGroupData>();

        services.AddAutoMapper(typeof(StudentsAutoMapper));

        return services;
    }
}
