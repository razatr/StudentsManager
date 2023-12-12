using Microsoft.AspNetCore.Mvc;
using StudentsManager.DAL.Entities;
using StudentsManager.Interfaces;
using StudentsManager.ViewModels;

namespace StudentsManager.Controllers;

public class StudentsController : Controller
{
    private readonly IStudentsData _studentsManager;
    public StudentsController(IStudentsData StudentsManager)
    {
        _studentsManager = StudentsManager;
    }

    private StudentViewModel Convert(Student student)
    {
        return student == null ?
            new StudentViewModel()
            : new StudentViewModel(student);
    }

    private Student Convert(StudentViewModel studView)
    {
        if (studView is null)
        {
            return new Student();
        }

        return new Student
        {
            LastName = studView.LastName,
            Name = studView.Name,
            Patronymic = studView.Patronymic,
            StudentsGroupId = studView.GroupId,
        };
    }

    public IActionResult Index()
    {
        var studList = _studentsManager
            .GetAll()
            .OrderBy(stud => stud.Id)
            .Select(Convert);
        return View(studList);
    }

    public IActionResult Edit(int id)
    {
        var student = _studentsManager.GetById(id);
        var studentView = Convert(student);

        return View(studentView);
    }

    [HttpPost]
    public IActionResult Create(StudentViewModel studView)
    {
        var stud = Convert(studView);
        _studentsManager.AddAndSave(stud);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Edit(StudentViewModel studView)
    {
        var student = Convert(studView);
        _studentsManager.UpdateAndSave(student);

        return RedirectToAction("Index");
    }

    [HttpGet]
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _studentsManager.RemoveAndSave(id);

        return RedirectToAction("Index");
    }
}
