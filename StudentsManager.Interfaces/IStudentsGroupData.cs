using StudentsManager.DAL.Entities;

namespace StudentsManager.Interfaces;

public interface IStudentsGroupData
{
    public IEnumerable<StudentsGroup> GetAll();
    StudentsGroup GetById(int id);
    void AddAndSave(StudentsGroup data);
    void UpdateAndSave(StudentsGroup data);
    void RemoveAndSave(int id);
}
