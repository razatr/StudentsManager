using Microsoft.AspNetCore.Mvc;
using StudentsManager.DAL.Entities;
using StudentsManager.Interfaces;
using StudentsManager.Services;
using StudentsManager.ViewModels;

namespace StudentsManager.Controllers;

public class StudentsGroupController : Controller
{
    private readonly IDataManager<StudentsGroup> _groupManager;
    private readonly IDataManager<Student> _studentManager;
    public StudentsGroupController(IDataManager<StudentsGroup> GroupManager, IDataManager<Student> studentManager)
    {
        _groupManager = GroupManager;
        _studentManager = studentManager;
    }

    public IActionResult Index()
    {
        var groups = _groupManager
            .GetAll()
            .OrderBy(group => group.Id)
            .Select(group => Mapper.Convert(group, Array.Empty<Student>()));

        return View(groups);
    }

    public IActionResult Edit(int id)
    {
        if (id == 0)
        {
            return View(new StudentsGroupViewModel());
        }
        var group = _groupManager.GetById(id);
        var students = group.Students.ToArray();
        var groupView = Mapper.Convert(group, students);
        return View(groupView);
    }

    [HttpPost]
    public IActionResult Edit(StudentsGroupViewModel groupView)
    {
        var group = Mapper.Convert(groupView);
        if (group.Id <= 0)
        {
            _groupManager.AddAndSave(group);
        }
        else
        {
            _groupManager.UpdateAndSave(group);
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _groupManager.RemoveAndSave(id);
        return RedirectToAction("Index");
    }
}
