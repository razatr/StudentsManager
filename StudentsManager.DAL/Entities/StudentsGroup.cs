using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StudentsManager.DAL.Entities.Base;
namespace StudentsManager.DAL.Entities;

public class StudentsGroup: NamedEntity
{
    private ICollection<Student> _students;
    public StudentsGroup()
    {
    }
    private StudentsGroup(ILazyLoader lazyLoader)
    {
        LazyLoader = lazyLoader;
    }
    private ILazyLoader LazyLoader { get; set; }
    public string? Description { get; set; }
    public ICollection<Student> Students
    {
        get => LazyLoader.Load(this, ref _students);
        set => _students = value;
    }
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
