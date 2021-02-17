using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Room.API.Entities
{
    public class MeetingRoom
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Location { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();

    }

}
