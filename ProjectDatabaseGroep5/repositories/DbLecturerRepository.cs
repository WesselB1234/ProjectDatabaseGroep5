using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProjectDatabaseGroep5.Models;
using static ProjectDatabaseGroep5.repositories.DbLecturerRepository;

namespace ProjectDatabaseGroep5.repositories
{
    public class DbLecturerRepository : ILecturerRepository 
    {
        private readonly string? _connectionString;

        public DbLecturerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("WhatsUpDatabase");
        }

        public void Add(Lecturer lecturer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"INSERT INTO Users (First_Name, Last_Name, TelefoonNumber, Age) " +
                    "VALUES (@firstname, @lastname, @TelNumber, @age);" +
                    "SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@firstname", lecturer.First_Name);
                command.Parameters.AddWithValue("@lastname", lecturer.Last_Name);
                command.Parameters.AddWithValue("@TelNumber", lecturer.TelefoonNumber);
                command.Parameters.AddWithValue("@age", lecturer.Age);

                command.Connection.Open();
                lecturer.ID = Convert.ToInt32(command.ExecuteScalar());


            }

        }

        public List<Lecturer> GetAll()
        {
            List<Lecturer> lecturers = new List<Lecturer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "Select First_Name, Last_Name, phone_number, Age FROM Lecturer";
                SqlCommand command = new SqlCommand(query, connection);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // ...
                    Lecturer lecturer = ReadUser(reader);
                    lecturers.Add(lecturer);
                }
                reader.Close();
            }
            return lecturers;
        }

        private Lecturer ReadUser(SqlDataReader reader)
        {
            string firstname = (string)reader["First_Name"];
            string lastname = (string)reader["Last_Name"];
            string TelNumber = (string)reader["phone_number"];
            int Age = (int)reader["age"];

            return new Lecturer(firstname, lastname, TelNumber, Age);

        }

        public Lecturer? GetById(int lecturerId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Lecturer lecturer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"DELETE FROM Users WHERE lecturerId = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", lecturer.ID);

                command.Connection.Open();
                int nrOfRowsAffected = command.ExecuteNonQuery();
                if (nrOfRowsAffected == 0)
                {
                    throw new Exception("no records deleted");
                }

            }
        }

        public void Update(Lecturer lecturer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Users SET UserName = @Name, MobileNumber = @MobileNumber, " +
                    ", Emailadress = @EmailAdress WHERE UserId = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", lecturer.First_Name);
                command.Parameters.AddWithValue("Name", lecturer.Last_Name);
                command.Parameters.AddWithValue("@MobileNumber", lecturer.TelefoonNumber);
                command.Parameters.AddWithValue("EmailAddress", lecturer.Age);

                command.Connection.Open();
                int nrOfRowsAffected = command.ExecuteNonQuery();
                if (nrOfRowsAffected == 0)
                {
                    throw new Exception("no records updated");
                }
            }
        }
    }
}
