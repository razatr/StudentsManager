using Microsoft.EntityFrameworkCore;
using StudentsManager.DAL.Context;
using StudentsManager.DAL.Entities.Base;
using StudentsManager.Interfaces;

namespace StudentsManager.Services.Base;

public abstract class DataManager<T> : IDataManager<T> where T : NamedEntity, new()
{
    protected readonly StudentsDB _db;
    protected DbSet<T> _EntitySet;
    public DataManager(StudentsDB db, DbSet<T> EntitySet)
    {
        _db = db;
        _EntitySet = EntitySet;
    }

    protected abstract void Update(T entity, T source);


    public IEnumerable<T> GetAll() => _EntitySet.AsEnumerable();

    public T? GetById(int id)
    {
        if (id == 0)
        {
            return null;
        }

        return _EntitySet.FirstOrDefault(entity => entity.Id == id);
    }

    public void AddAndSave(T data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        if (data.Id != 0)
        {
            throw new ArgumentException("Invalid Id property of student to add.");
        }

        _EntitySet.Add(data);
        _db.SaveChanges();
    }

    public void UpdateAndSave(T data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        var entity = GetById(data.Id);
        if (entity is null)
        {
            // Надо бы добавить логирование
            return;
        }

        Update(entity, data);
        _db.SaveChanges();
    }

    public void RemoveAndSave(int id)
    {
        if (id == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }

        var entity = GetById(id);
        if (entity is null)
        {
            // логирование
            return;
        }

        _EntitySet.Remove(entity);
        _db.SaveChanges();
    }
}
