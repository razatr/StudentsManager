using Microsoft.AspNetCore.Mvc;
using StudentsManager.DAL.Context;
using StudentsManager.ViewModels;

namespace StudentsManager.Controllers
{
    public class StudentsGroupController : Controller
    {
        public StudentsDB Db { get; set; }
        public StudentsGroupController(StudentsDB db)
        {
            Db = db;
        }

        public IActionResult Index()
        {
            var groups = Db.StudentsGroups
                .OrderBy(group => group.Id)
                .Select(group => new StudentsGroupViewModel(group));

            return View(groups);
        }
    }
}
