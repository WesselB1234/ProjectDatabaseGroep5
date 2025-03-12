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

        public IActionResult Index()
        {
            List<Room> rooms = _roomsRepository.GetAll();
            return View(rooms);
        }
    }
}
