using StudentsManager.Interfaces;
using StudentsManager.DAL.Entities;
using StudentsManager.DAL.Context;

namespace StudentsManager.Services;

public class DbStudentsGroupData : IStudentsGroupData
{
    private readonly StudentsDB _db;
    public DbStudentsGroupData(StudentsDB db)
    {
        _db = db;
    }


    public IEnumerable<StudentsGroup> GetAll() => _db.StudentsGroups.AsEnumerable();
    public StudentsGroup GetById(int id)
    {
        if (id == 0)
        {
            return new StudentsGroup();
        }

        return _db.StudentsGroups.FirstOrDefault(group => group.Id == id) ?? new StudentsGroup();
    }

    public void AddAndSave(StudentsGroup group)
    {
        if (group is null)
        {
            throw new ArgumentNullException(nameof(group));
        }
        if (group.Id != 0)
        {
            throw new ArgumentException("Invalid Id property of StudentsGroup to add.");
        }

        _db.StudentsGroups.Add(group);
        _db.SaveChanges();
    }

    public void UpdateAndSave(StudentsGroup data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        var group = GetById(data.Id);
        if (group is null)
        {
            // Надо бы добавить логирование
            return;
        }

        group.Name = data.Name;
        group.Description = data.Description;
        group.Students = data.Students;

        _db.SaveChanges();
    }

    public void RemoveAndSave(int id)
    {
        if (id == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }

        var group = GetById(id);
        if (group is null)
        {
            // логирование
            return;
        }

        _db.StudentsGroups.Remove(group);
        _db.SaveChanges();
    }
}
