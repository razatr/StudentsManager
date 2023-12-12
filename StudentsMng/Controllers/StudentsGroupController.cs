using Microsoft.AspNetCore.Mvc;
using StudentsManager.DAL.Entities;
using StudentsManager.Interfaces;
using StudentsManager.Services;
using StudentsManager.ViewModels;

namespace StudentsManager.Controllers;

public class StudentsGroupController : Controller
{
    private readonly IDataManager<StudentsGroup> _groupManager;
    public StudentsGroupController(IDataManager<StudentsGroup> GroupManager)
    {
        _groupManager = GroupManager;
    }

    public IActionResult Index()
    {
        var groups = _groupManager
            .GetAll()
            .OrderBy(group => group.Id)
            .Select(Mapper.Convert);

        return View(groups);
    }

    public IActionResult Edit(int id)
    {
        var group = _groupManager.GetById(id);
        var groupView = Mapper.Convert(group);
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
