using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Item.API.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public int Type { get; set; }
        public string MeetingRoomId { get; set; }
    }
}
