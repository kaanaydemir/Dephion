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
                    Name = "101",
                    Items = new List<Item>(){ new Item() { ItemId = "602d62a5eb7a112430e5f776", Name = "TV", Category = 1 } }
                },
                new MeetingRoom()
                {
                    Capacity = 7,
                    Location = 2,
                    Name = "102",
                    Items = new List<Item>(){ new Item() { ItemId = "602d62b7eb7a112430e5f777", Name = "Table", Category = 2 } }
                },
                new MeetingRoom()
                {
                    Capacity = 5,
                    Location = 1,
                    Name = "103",
                    Items = new List<Item>(){ new Item() { ItemId = "602d62c5eb7a112430e5f778", Name = "Desk", Category = 3 } }
                },
                new MeetingRoom()
                {
                    Capacity = 21,
                    Location = 2,
                    Name = "103",
                    Items = new List<Item>(){ new Item() { ItemId = "602d62c5eb7a112430e5f779", Name = "Xbox", Category = 4 } }
                },
                new MeetingRoom()
                {
                    Capacity = 34,
                    Location = 2,
                    Name = "104",
                    Items = new List<Item>(){ new Item() { ItemId = "602d62c5eb7a112430e5f780", Name = "Scanner", Category = 6 } }
                },
                new MeetingRoom()
                {
                    Capacity = 20,
                    Location = 1,
                    Name = "105",
                    Items = new List<Item>(){ new Item() { ItemId = "602d62c5eb7a112430e5f790", Name = "Phone", Category = 5} }
                },
            };
        }
    }
}
