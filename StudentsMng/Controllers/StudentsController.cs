using Microsoft.AspNetCore.Mvc;
using StudentsManager.DAL.Context;
using StudentsManager.DAL.Entities;
using StudentsManager.ViewModels;

namespace StudentsManagerCoop.Controllers
{
    public class StudentsController : Controller
    {
        public StudentsDB Db { get; set; }
        public StudentsController(StudentsDB db) 
        {
            Db = db;
        }

        private StudentsViewModel Convert(Student student)
        {
            return student == null ?
                new StudentsViewModel()
                : new StudentsViewModel(student);
        }

        private Student GetStudent(int id)
        {
            if (id == 0) {
                return new Student();
            }
            
            var student = Db.Students.FirstOrDefault(stud => stud.Id == id);
            return student ?? new Student();
        }

        private IEnumerable<StudentsViewModel> GetStudentsList()
        {
            return Db.Students
                .OrderBy(stud => stud.Id)
                .Select(stud => new StudentsViewModel(stud));
        }


        public IActionResult Index()
        {
            var studList = GetStudentsList();
            return View(studList);
        }

        public IActionResult Edit(int id)
        {
            var student = GetStudent(id);
            var studentView = Convert(student);

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
            Db.Students.Add(stud);

            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(StudentsViewModel studentView)
        {
            var student = GetStudent(studentView.Id);

            student.Name = studentView.Name;
            student.LastName = studentView.LastName;
            student.Patronymic = studentView.Patronymic;

            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(StudentsViewModel studentView)
        {
            var student = GetStudent(studentView.Id);
            Db.Students.Remove(student);

            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
