using Microsoft.AspNetCore.Mvc;
using ProjectDatabaseGroep5.Models;
using ProjectDatabaseGroep5.Repositories;

namespace ProjectDatabaseGroep5.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomsRepository _roomsRepository;

        public RoomsController(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        public IActionResult Index(int? size)
        {
            List<Room> rooms = [];

            if (size == null)
            {
                rooms = _roomsRepository.GetAll();
            }
            else
            {
                rooms = _roomsRepository.GetBySize(size);
                ViewData["Size"] = size;
            }

            return View(rooms);
        }
    }
}
