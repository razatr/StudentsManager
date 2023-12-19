//using StudentsManager.AutoMappers;
using StudentsManager.DAL.Entities;
using StudentsManager.Interfaces;
using StudentsManager.Services;

namespace StudentsManager.Models;

internal static class Registrator
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IDataManager<Student>, DbStudentsData>();
        services.AddScoped<IDataManager<StudentsGroup>, DbStudentsGroupData>();

        //services.AddAutoMapper(typeof(StudentsAutoMapper));

        return services;
    }
}
