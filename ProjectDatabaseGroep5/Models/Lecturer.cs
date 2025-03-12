namespace ProjectDatabaseGroep5.Models
{
    public class Lecturer
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string TelefoonNumber { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }

        public Lecturer() { }


        public Lecturer(string firstname, string lastname, string TelNumber, int age)
        {
            First_Name = firstname;
            Last_Name = lastname;
            TelefoonNumber = TelNumber;
            Age = age;
            

        }
    }
}
