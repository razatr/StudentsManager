using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsManager.DAL.Context;
using StudentsManager.ViewModels;

namespace StudentsManager.Components
{
    public class StudentsGroupsListViewComponent : ViewComponent
    {
        private readonly StudentsDB _db;

        public StudentsGroupsListViewComponent(StudentsDB db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var groups = _db.Students
                .Select(g => new StudentsGroupViewModel { Id = g.Id, Name = g.Name })
                .AsEnumerable();

            return View(groups);
        }
    }
}
