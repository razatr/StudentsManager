using StudentsManager.DAL.Entities.Base;

namespace StudentsManager.Interfaces;

public interface IDataManager<T> where T : NamedEntity, new()
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    void AddAndSave(T data);
    void UpdateAndSave(T data);
    void RemoveAndSave(int id);
}
