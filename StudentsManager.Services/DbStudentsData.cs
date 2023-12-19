using StudentsManager.DAL.Entities;
using StudentsManager.DAL.Context;
using StudentsManager.Services.Base;

namespace StudentsManager.Services;

public class DbStudentsData : DataManager<Student>
{
    public DbStudentsData(StudentsDB db) : base(db, db.Students) { }

    protected override void Update(Student student, Student source)
    {
        student.Name = source.Name;
        student.LastName = source.LastName;
        student.Patronymic = source.Patronymic;
        student.StudentsGroupId = source.StudentsGroupId;
    }
}
