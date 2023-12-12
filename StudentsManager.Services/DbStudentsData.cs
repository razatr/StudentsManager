using StudentsManager.Interfaces;
using StudentsManager.DAL.Entities;
using StudentsManager.DAL.Context;

namespace StudentsManager.Services;

public class DbStudentsData : IStudentsData
{
    private readonly StudentsDB _db;
    public DbStudentsData(StudentsDB db)
    {
        _db = db;
    }


    public IEnumerable<Student> GetAll() => _db.Students.AsEnumerable();
    public Student? GetById(int id)
    {
        if (id == 0)
        {
            return new Student();
        }

        return _db.Students.FirstOrDefault(stud => stud.Id == id);
    }

    public void AddAndSave(Student stud)
    {
        if (stud is null)
        {
            throw new ArgumentNullException(nameof(stud));
        }
        if (stud.Id != 0)
        {
            throw new ArgumentException("Invalid Id property of student to add.");
        }

        _db.Students.Add(stud);
        _db.SaveChanges();
    }

    public void UpdateAndSave(Student data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        var stud = GetById(data.Id);
        if (stud is null)
        {
            // Надо бы добавить логирование
            return;
        }

        stud.Name = data.Name;
        stud.LastName = data.LastName;
        stud.Patronymic = data.Patronymic;
        stud.StudentsGroupId = data.StudentsGroupId;

        _db.SaveChanges();
    }

    public void RemoveAndSave(int id)
    {
        if (id == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }

        var stud = GetById(id);
        if (stud is null)
        {
            // логирование
            return;
        }

        _db.Students.Remove(stud);
        _db.SaveChanges();
    }
}
