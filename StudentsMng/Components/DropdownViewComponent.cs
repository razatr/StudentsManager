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

    public async Task<IViewComponentResult> InvokeAsync(int groupId)
    {
        var groups = _db.StudentsGroups
                .Select(g => new GroupElementViewModel { Id = g.Id, Name = g.Name, Selected = groupId == g.Id })
                .AsEnumerable();

        return View(groups);
    }
}