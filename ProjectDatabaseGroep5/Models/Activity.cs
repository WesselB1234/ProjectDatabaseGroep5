namespace ProjectDatabaseGroep5.Models
{
    public class Activity
    {
        public int activity_id { get; set; }
        public string name { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }

        public Activity()
        {
            activity_id = 0;
            name = "";
            start_date = "";
            end_date = "";
        }

        public Activity(int id, string names, string startDate, string endDate)
        {
            activity_id = id;
            name = names;
            start_date = startDate;
            end_date = endDate;
        }
    }
}
