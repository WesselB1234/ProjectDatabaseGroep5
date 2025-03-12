using ProjectDatabaseGroep5.Models;

namespace ProjectDatabaseGroep5.Repositories
{
    public interface IRoomsRepository
    {
        List<Room> GetAll();
        Room? GetById(int userId);
        void Add(Room room);
        void Update(Room room);
        void Delete(Room room);
    }
}
