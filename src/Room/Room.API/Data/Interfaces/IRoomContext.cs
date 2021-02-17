using System;
using MongoDB.Driver;
using Room.API.Entities;

namespace Room.API.Data.Interfaces
{
    public interface IRoomContext
    {
        IMongoCollection<MeetingRoom> MeetingRooms { get; }
    }
}
