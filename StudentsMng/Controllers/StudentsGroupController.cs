using Microsoft.AspNetCore.Mvc;
using StudentsManager.DAL.Context;
using StudentsManager.DAL.Entities;
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

        private StudentsGroup GetStudentsGroup(int id)
        {
            if (id == 0)
            {
                return new StudentsGroup();
            }

            var group = Db.StudentsGroups.FirstOrDefault(g => g.Id == id);
            return group == null ? new StudentsGroup() : group;

        }

        private IEnumerable<StudentsGroupViewModel> GetStudentsGroupList()
        {
            return Db.StudentsGroups
                .OrderBy(group => group.Id)
                .Select(group => new StudentsGroupViewModel(group));
        }

        public IActionResult Index()
        {
            var groups = GetStudentsGroupList();
            return View(groups);
        }

        public IActionResult Edit(int id)
        {
            var group = GetStudentsGroup(id);
            var groupView = new StudentsGroupViewModel(group);

            return View(groupView);
        }

        [HttpPost]
        public IActionResult Create(StudentsGroupViewModel groupView)
        {
            var newGroup = new StudentsGroup {
                Name = groupView.Name,
                Description = groupView.Description,
                Students = (ICollection<Student>)(
                    groupView.StudentsList == null ?
                        new HashSet<StudentViewModel>()
                        : groupView.StudentsList.ToHashSet()
                    ),
            };
            Db.StudentsGroups.Add(newGroup);

            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditInfo(StudentsGroupViewModel groupView)
        {
            var group = GetStudentsGroup(groupView.Id);
            
            group.Name = groupView.Name;
            group.Description = groupView.Description;

            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(StudentsGroupViewModel groupView)
        {
            var group = GetStudentsGroup(groupView.Id);
            Db.StudentsGroups.Remove(group);

            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
