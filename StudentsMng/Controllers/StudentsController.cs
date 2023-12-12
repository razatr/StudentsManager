using Microsoft.AspNetCore.Mvc;
using StudentsManager.DAL.Entities;
using StudentsManager.Interfaces;
using StudentsManager.Services;
using StudentsManager.ViewModels;
using System.Text.RegularExpressions;

namespace StudentsManager.Controllers;

public class StudentsController : Controller
{
    private readonly IStudentsData _studentsManager;
    public StudentsController(IStudentsData StudentsManager)
    {
        _studentsManager = StudentsManager;
    }

    public IActionResult Index()
    {
        var studList = _studentsManager
            .GetAll()
            .OrderBy(stud => stud.Id)
            .Select(Mapper.Convert);
        return View(studList);
    }

    public IActionResult Edit(int id)
    {
        var student = _studentsManager.GetById(id);
        var studentView = Mapper.Convert(student);

        return View(studentView);
    }

    [HttpPost]
    public IActionResult Edit(StudentViewModel studView)
    {
        var stud = Mapper.Convert(studView);
        if (stud.Id <= 0)
        {
            _studentsManager.AddAndSave(stud);
        }
        else
        {
            _studentsManager.UpdateAndSave(stud);
        }

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
