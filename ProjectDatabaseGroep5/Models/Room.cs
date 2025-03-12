namespace ProjectDatabaseGroep5.Models
{ 
    public class Room
    {
        public int RoomId { get; set; }
        public int BuildingId { get; set; }
        public int Story {  get; set; }
        public int LocationNumber { get; set; }
        public int AvailableBeds { get; set; }


        public Room()
        {

        }

        public Room(int roomId, int buildingId, int story, int locationNumber, int availableBeds)
        {
            RoomId = roomId;
            BuildingId = buildingId;
            Story = story;
            LocationNumber = locationNumber;
            AvailableBeds = availableBeds;
        }
    }
}
