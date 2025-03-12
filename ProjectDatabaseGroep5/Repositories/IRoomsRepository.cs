using ProjectDatabaseGroep5.Models;

namespace ProjectDatabaseGroep5.Repositories
{
    public interface IRoomsRepository
    {
        List<Room> GetAll();
        Room? GetById(int userId);
        List<Room> GetBySize(int? size);
        void Add(Room room);
        void Update(Room room);
        void Delete(Room room);
    }
}
