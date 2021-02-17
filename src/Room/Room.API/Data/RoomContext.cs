using System;
using MongoDB.Driver;
using Room.API.Data.Interfaces;
using Room.API.Entities;
using Room.API.Settings;

namespace Room.API.Data
{
    public class RoomContext : IRoomContext
    {
        public RoomContext(IRoomDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            MeetingRooms = database.GetCollection<MeetingRoom>(settings.CollectionName);

            RoomContextSeed.SeedData(MeetingRooms);
        }

        public IMongoCollection<MeetingRoom> MeetingRooms { get; }
    }
}
