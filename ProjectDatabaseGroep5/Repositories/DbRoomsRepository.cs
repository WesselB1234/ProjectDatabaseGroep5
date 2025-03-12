using Microsoft.Data.SqlClient;
using ProjectDatabaseGroep5.Models;
using ProjectDatabaseGroep5.Repositories;
using System.Reflection.PortableExecutable;

namespace MvcWhatsUp.Repositories
{
    public class DbRoomsRepository : IRoomsRepository
    {
        private readonly string? _connectionString;

        public DbRoomsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("WhatsUpDatabase");
        }

        public void Add(Room room)
        {
            //using (SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    string query = "INSERT INTO Users(UserName, MobileNumber, EmailAddress, Password) " +
            //        $"VALUES (@UserName, @MobileNumber, @EmailAddress, @Password);" +
            //        "SELECT SCOPE_IDENTITY();";
            //    SqlCommand command = new SqlCommand(query, connection);

            //    command.Parameters.AddWithValue("@UserName", user.UserName);
            //    command.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
            //    command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
            //    command.Parameters.AddWithValue("@Password", user.Password);

            //    command.Connection.Open();
            //    user.UserId = Convert.ToInt32(command.ExecuteScalar());
            //}
        }

        private Room ReadRoom(SqlDataReader reader)
        {
            int id = (int)reader["room_id"];
            int buildingId = (int)reader["building_id"];
            int story = (int)reader["story"];
            int locationNumber = (int)reader["location_number"];
            int availableBeds = (int)reader["available_beds"];

            return new Room(id, buildingId, story, locationNumber, availableBeds);
        }

        public List<Room> GetAll()
        {
            List<Room> rooms = new List<Room>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Room ORDER BY [building_id], [story], [location_number]";
                SqlCommand command = new SqlCommand(query, connection);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Room room = ReadRoom(reader);
                    rooms.Add(room);
                }

                reader.Close();
            }

            return rooms;
        }

        public Room? GetById(int roomId)
        {
            //User user = null;

            //using (SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    string query = "SELECT * FROM Users WHERE UserId = @Id";

            //    SqlCommand command = new SqlCommand(query, connection);

            //    command.Parameters.AddWithValue("@Id", userId);

            //    command.Connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        user = ReadUser(reader);
            //    }
            //}

            //return user;

            return null;
        }

        public void Update(Room room)
        {
            //using (SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    string query = "UPDATE Users SET UserName = @UserName, MobileNumber = @MobileNumber, EmailAddress = @EmailAddress, Password = @password " +
            //        $" WHERE UserId = @Id";

            //    SqlCommand command = new SqlCommand(query, connection);

            //    command.Parameters.AddWithValue("@Id", user.UserId);
            //    command.Parameters.AddWithValue("@UserName", user.UserName);
            //    command.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
            //    command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
            //    command.Parameters.AddWithValue("@Password", user.Password);

            //    command.Connection.Open();
            //    int result = command.ExecuteNonQuery();

            //    if (result == 0)
            //    {
            //        throw new Exception("No records have been updated");
            //    }
            //}
        }

        public void Delete(Room room)
        {
            //using (SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    string query = $"DELETE FROM Users WHERE UserId = @Id";

            //    SqlCommand command = new SqlCommand(query, connection);

            //    command.Parameters.AddWithValue("@Id", user.UserId);

            //    command.Connection.Open();
            //    int result = command.ExecuteNonQuery();

            //    if (result == 0)
            //    {
            //        throw new Exception("No records have been deleted");
            //    }
            //}
        }
    }
}
