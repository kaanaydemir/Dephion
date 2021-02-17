using System;
namespace Room.API.Settings
{
    public class RoomDatabaseSettings : IRoomDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
