using Microsoft.AspNetCore.Mvc;
using StudentsManager.DAL.Context;
using StudentsManager.DAL.Entities;
using StudentsManager.Models;

namespace StudentsManagerCoop.Controllers
{
    public class StudentsController : Controller
    {
        public StudentsDB db { get; set; }
        public StudentsController(StudentsDB db) 
        {
            this.db = db;
        }

        private Student? GetStudent(int id)
        {
            return id == 0 ?
                new Student()
                : db.Students.FirstOrDefault(stud => stud.Id == id);
        }

        // Тоже временная функция
        private IEnumerable<StudentsViewModel> GetStudents()
        {
            // return Provider.GetStudents();
            return db.Students
                .OrderBy(stud => stud.Id)
                .Select(stud => new StudentsViewModel(stud));
        }


        public IActionResult Index()
        {
            var studList = GetStudents();
            return View(studList);
        }

        public IActionResult Edit(int id)
        {
            var student = GetStudent(id);
            var studentView = student == null ?
                new StudentsViewModel()
                : new StudentsViewModel(student);

            return View(studentView);
        }

        [HttpPost]
        public IActionResult Create(StudentsViewModel studView)
        {
            var stud = new Student
            {
                LastName = studView.LastName,
                Name = studView.Name,
                Patronymic = studView.Patronymic
            };
            db.Students.Add(stud);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(StudentsViewModel studentView)
        {
            var student = GetStudent(studentView.Id);

            student.Name = studentView.Name;
            student.LastName = studentView.LastName;
            student.Patronymic = studentView.Patronymic;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(StudentsViewModel studentView)
        {
            var student = GetStudent(studentView.Id);
            db.Students.Remove(student);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
