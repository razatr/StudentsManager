using Microsoft.AspNetCore.Mvc;
using StudentsManager.DAL.Context;
using StudentsManager.Interfaces;
using StudentsManager.Services;
using StudentsManager.ViewModels;

namespace StudentsManager.Components;

public class DropdownViewComponent : ViewComponent
{
    private readonly IStudentsGroupData _groupManager;

    public DropdownViewComponent(IStudentsGroupData GroupManager)
    {
        _groupManager = GroupManager;
    }

    public IViewComponentResult Invoke(int groupId)
    {
        var groups = _groupManager.GetAll()
                .Select(g => new GroupElementViewModel { Id = g.Id, Name = g.Name, Selected = groupId == g.Id })
                .AsEnumerable();
        var dropdown = new DropdownViewModel(groups);

        return View(dropdown);
    }
}