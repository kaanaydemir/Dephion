using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Room.API.Entities;

namespace Room.API.Data
{
    public class RoomContextSeed
    {
        public static void SeedData(IMongoCollection<MeetingRoom> collection)
        {
            bool existMeetingRoom = collection.Find(p => true).Any();

            if (!existMeetingRoom)
                collection.InsertManyAsync(GetPreconfiguredProducts());
        }

        private static IEnumerable<MeetingRoom> GetPreconfiguredProducts()
        {
            return new List<MeetingRoom>()
            {
                new MeetingRoom()
                {
                    Capacity = 11,
                    Location = 1,
                    Name = "Big",
                    Items = new List<Item>(){ new Item() { ItemId = "1", Name = "TV", Category = 1 }, new Item() { ItemId = "1", Name = "PC", Category = 2 } }
                },
                new MeetingRoom()
                {
                    Capacity = 7,
                    Location = 2,
                    Name = "Medium",
                    Items = new List<Item>(){ new Item() { ItemId = "1", Name = "Table", Category = 1 } }
                },
                new MeetingRoom()
                {
                    Capacity = 5,
                    Location = 2,
                    Name = "Small",
                    Items = new List<Item>(){ new Item() { ItemId = "1", Name = "Desk", Category = 1 } }
                },
            };
        }
    }
}
