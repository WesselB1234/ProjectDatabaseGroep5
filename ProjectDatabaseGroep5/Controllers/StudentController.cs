using Microsoft.AspNetCore.Mvc;

namespace ProjectDatabaseGroep5.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
