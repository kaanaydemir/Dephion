using System;
namespace Room.API.Settings
{
    public interface IRoomDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
