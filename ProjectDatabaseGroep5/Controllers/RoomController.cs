using Microsoft.AspNetCore.Mvc;
using ProjectDatabaseGroep5.Models;
using ProjectDatabaseGroep5.Repositories;

namespace ProjectDatabaseGroep5.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomsRepository _roomsRepository;

        public RoomController(IRoomsRepository roomsRepository)
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
