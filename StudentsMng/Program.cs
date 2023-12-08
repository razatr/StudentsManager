using Microsoft.EntityFrameworkCore;
using StudentsManager.DAL.Context;
using StudentsManager.Interfaces;
using StudentsManager.Models;
using StudentsManager.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var db_connection_str = builder.Configuration.GetConnectionString("default");

// Add services to the container.
services.AddDbContext<StudentsDB>(
    options => {
        options.UseSqlServer(db_connection_str);
    }
);
services.AddScoped<IStudentsData, DbStudentsData>();
services.AddScoped<IStudentsGroupData, DbStudentsGroupData>();

services.AddControllersWithViews();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    await SeedData.Initialize(serviceProvider);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
