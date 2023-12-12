using StudentsManager.DAL.Entities;

namespace StudentsManager.Interfaces;

public interface IStudentsData
{
    public IEnumerable<Student> GetAll();
    Student? GetById(int id);
    void AddAndSave(Student data);
    void UpdateAndSave(Student data);
    void RemoveAndSave(int id);
}
