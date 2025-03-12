using ProjectDatabaseGroep5.Models;

namespace ProjectDatabaseGroep5.Repositories
{
    public interface IActivitiesRepository
    {
        List<Activity> GetAll();
        Activity? GetById(int id);
        public void Add(Activity activity);
        public void Update(Activity activity);
        public void Delete(Activity activity);
    }
}
