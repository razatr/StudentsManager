using Microsoft.AspNetCore.Mvc;
using StudentsManager.DAL.Entities;
using StudentsManager.Interfaces;
using StudentsManager.ViewModels;

namespace StudentsManager.Controllers;

public class StudentsGroupController : Controller
{
    private readonly IStudentsGroupData _groupManager;
    public StudentsGroupController(IStudentsGroupData GroupManager)
    {
        _groupManager = GroupManager;
    }

    private StudentsGroup Convert(StudentsGroupViewModel groupView)
    {
        var studentsList = groupView.StudentsList is null ? new HashSet<Student>()
            : groupView.StudentsList
                .Select(stud => new Student
                {
                    Id = stud.Id,
                    Name = stud.Name,
                    LastName = stud.LastName,
                    Patronymic = stud.Patronymic,
                    StudentsGroupId = stud.GroupId,
                })
                .ToHashSet();

        var group = new StudentsGroup
        {
            Id = groupView.Id,
            Name = groupView.Name,
            Description = groupView.Description,
            Students = studentsList
        };

        return group;
    }

    private StudentsGroupViewModel Convert(StudentsGroup group)
    {
        return group is null ? new StudentsGroupViewModel() : new StudentsGroupViewModel(group);
    }

    public IActionResult Index()
    {
        var groups = _groupManager
            .GetAll()
            .OrderBy(group => group.Id)
            .Select(Convert);

        return View(groups);
    }

    public IActionResult Edit(int id)
    {
        var group = _groupManager.GetById(id);
        var groupView = Convert(group);
        return View(groupView);
    }

    [HttpPost]
    public IActionResult Edit(StudentsGroupViewModel groupView)
    {
        var group = Convert(groupView);
        _groupManager.UpdateAndSave(group);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Create(StudentsGroupViewModel groupView)
    {
        var group = Convert(groupView);
        _groupManager.AddAndSave(group);

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
