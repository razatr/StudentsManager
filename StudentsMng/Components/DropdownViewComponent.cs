using Microsoft.AspNetCore.Mvc;
using StudentsManager.DAL.Entities;
using StudentsManager.Interfaces;
using StudentsManager.ViewModels;

namespace StudentsManager.Components;

public class DropdownViewComponent : ViewComponent
{
    private readonly IDataManager<StudentsGroup> _groupManager;

    public DropdownViewComponent(IDataManager<StudentsGroup> GroupManager)
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