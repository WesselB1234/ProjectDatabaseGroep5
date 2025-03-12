using Microsoft.AspNetCore.Mvc;
using ProjectDatabaseGroep5.Models;
using ProjectDatabaseGroep5.repositories;

namespace ProjectDatabaseGroep5.Controllers
{
    public class LecturerController : Controller
    {

        private readonly ILecturerRepository _lecturerRepositorys;

        public LecturerController(ILecturerRepository lecturerRepositorys)
        {
            _lecturerRepositorys = lecturerRepositorys;
        }

        public IActionResult Index()
        {
            List<Lecturer> lecturers = _lecturerRepositorys.GetAll();

            return View(lecturers);
        }

    }
}
