using ProjectDatabaseGroep5.Models;

namespace ProjectDatabaseGroep5.repositories
{
    public interface ILecturerRepository
    {
        List<Lecturer> GetAll();
        Lecturer? GetById(int lecturerid);
        void Add(Lecturer lecturer);
        void Update(Lecturer lecturer);
        void Remove(Lecturer lecturer);
    }
}
