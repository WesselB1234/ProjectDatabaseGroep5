using Microsoft.Data.SqlClient;
using ProjectDatabaseGroep5.Models;

namespace ProjectDatabaseGroep5.Repositories
{
    public class DBActivitiesRepository : IActivitiesRepository
    {
        private readonly string? _connectionString;

        public DBActivitiesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Someren");
        }

        public void Add(Activity activity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Activity (name, start_date, end_date) " +
                    "VALUES (@Name, @StartDate, @EndDate); " +
                    "SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", activity.name);
                command.Parameters.AddWithValue("@StartDate", activity.start_date);
                command.Parameters.AddWithValue("@EndDate", activity.end_date);

                command.Connection.Open();
                activity.activity_id = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Update(Activity activity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Activity SET name = @Name, start_date = @StartDate, " +
                    "end_date = @EndDate WHERE activity_id = @Id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", activity.name);
                command.Parameters.AddWithValue("@StartDate", activity.start_date);
                command.Parameters.AddWithValue("@EndDate", activity.end_date);
                command.Parameters.AddWithValue("@Id", activity.activity_id);

                command.Connection.Open();
                int nrOfRowsAffected = command.ExecuteNonQuery();
                if (nrOfRowsAffected == 0)
                {
                    throw new Exception("No records updated!");
                }
            }
        }

        public void Delete(Activity activity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Activity WHERE activity_id = @Id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", activity.activity_id);

                command.Connection.Open();
                int nrOfRowsAffected = command.ExecuteNonQuery();
                if (nrOfRowsAffected == 0)
                {
                    throw new Exception("No records deleted!");
                }
            }
        }

        public List<Activity> GetAll()
        {
            List<Activity> activities = new List<Activity>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT activity_id, start_date FROM Activity";
                SqlCommand command = new SqlCommand(query, connection);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Activity activity = ReadActivity(reader);
                    activities.Add(activity);
                }
                reader.Close();
            }
            return activities;
        }

        private Activity ReadActivity(SqlDataReader reader)
        {
            int id = (int)reader["activity_id"];
            string names = (string)reader["name"];
            string startDate = (string)reader["start_date"];
            string endDate = (string)reader["end_date"];

            return new Activity(id, names, startDate, endDate);
        }



        public Activity? GetById(int id)
        {
            Activity activity = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT activity_id, name, start_date, end_date FROM Activity WHERE activity_id = @Id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", id);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    activity = ReadActivity(reader);
                }
                reader.Close();
            }
            return activity;
        }
    }
}
