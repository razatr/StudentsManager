using Microsoft.EntityFrameworkCore;
using StudentsManager.DAL.Entities;

namespace StudentsManager.DAL.Context
{
    public class StudentsDB : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentsGroup> StudentsGroups { get; set; }

        public StudentsDB(DbContextOptions options): base(options) 
        {

        }
    }
}
