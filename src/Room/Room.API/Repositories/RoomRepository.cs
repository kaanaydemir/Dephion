using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Room.API.Data.Interfaces;
using Room.API.Entities;
using Room.API.Repositories.Interfaces;

namespace Room.API.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IRoomContext _context;

        public RoomRepository(IRoomContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MeetingRoom>> GetMeetingRooms()
        {
            return await _context
                            .MeetingRooms
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<MeetingRoom> GetMeetingRoom(string id)
        {
            return await _context
                            .MeetingRooms
                            .Find(p => p.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MeetingRoom>> GetMeetingRoomByCapacity(int capacity)
        {
            return await _context
                            .MeetingRooms
                            .Find(p => p.Capacity >= capacity)
                            .ToListAsync();
        }

        public async Task<IEnumerable<MeetingRoom>> GetMeetingRoomsByLocation(int location)
        {
            return await _context
                            .MeetingRooms
                            .Find(p => p.Location == location)
                            .ToListAsync();
        }

        public async Task Create(MeetingRoom meetingRoom)
        {
            await _context.MeetingRooms.InsertOneAsync(meetingRoom);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<MeetingRoom> filter = Builders<MeetingRoom>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .MeetingRooms
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> Update(MeetingRoom meetingRoom)
        {
            var updateResult = await _context
                                        .MeetingRooms
                                        .ReplaceOneAsync(filter: g => g.Id == meetingRoom.Id, replacement: meetingRoom);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
