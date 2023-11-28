using Microsoft.AspNetCore.Mvc;
using StudentsManager.DAL.Context;
using StudentsManager.ViewModels;

namespace StudentsManager.Components;

public class DropdownViewComponent : ViewComponent
{
    private readonly StudentsDB _db;

    public DropdownViewComponent(StudentsDB db)
    {
        _db = db;
    }

    public IViewComponentResult Invoke(string GroupId)
    {
        var groups = _db.Students
                .Select(g => new StudentsGroupViewModel { Id = g.Id, Name = g.Name })
                .AsEnumerable();

        return View(groups);
    }
}