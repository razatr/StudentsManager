using StudentsManager.DAL.Entities;
using StudentsManager.DAL.Context;
using StudentsManager.Services.Base;

namespace StudentsManager.Services;

public class DbStudentsGroupData : DataManager<StudentsGroup>
{
    public DbStudentsGroupData(StudentsDB db) : base(db, db.StudentsGroups) { }

    protected override void Update(StudentsGroup group, StudentsGroup source)
    {
        group.Name = source.Name;
        group.Description = source.Description;
        group.Students = source.Students;
        group.Courses = source.Courses;
    }
}
