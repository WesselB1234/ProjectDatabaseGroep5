using Microsoft.AspNetCore.Mvc;
using ProjectDatabaseGroep5.Models;
using ProjectDatabaseGroep5.Repositories;

namespace ProjectDatabaseGroep5.Controllers
{
    public class ActivitiesController : Controller
    {

        private IActivitiesRepository _activitiesRepository;

        public ActivitiesController(IActivitiesRepository activitiesRepository)
        {
            _activitiesRepository = activitiesRepository;
        }

        public IActionResult Index()
        {
            List<Activity> activities = _activitiesRepository.GetAll();
            return View(activities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Activity activity)
        {
            try
            {
                _activitiesRepository.Add(activity);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(activity);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Activity? user = _activitiesRepository.GetById((int)id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(Activity activity)
        {
            try
            {
                _activitiesRepository.Update(activity);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(activity);
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Activity? user = _activitiesRepository.GetById((int)id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(Activity activity)
        {
            try
            {
                _activitiesRepository.Delete(activity);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(activity);
            }
        }
    }
}
