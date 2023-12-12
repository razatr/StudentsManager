using Microsoft.EntityFrameworkCore;
using StudentsManager.DAL.Entities;

namespace StudentsManager.DAL.Context
{
    public class StudentsDB : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentsGroup> StudentsGroups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ScheduleEntity> Schedule { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public StudentsDB(DbContextOptions options): base(options) 
        {

        }
/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>();
        }*/
    }
}
