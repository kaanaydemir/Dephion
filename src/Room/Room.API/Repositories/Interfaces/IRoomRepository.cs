using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Room.API.Entities;

namespace Room.API.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<MeetingRoom>> GetMeetingRooms();
        Task<MeetingRoom> GetMeetingRoom(string id);
        Task<IEnumerable<MeetingRoom>> GetMeetingRoomByCapacity(int capacity);
        Task<IEnumerable<MeetingRoom>> GetMeetingRoomsByLocation(int location);

        Task Create(MeetingRoom meetingRoom);
        Task<bool> Update(MeetingRoom meetingRoom);
        Task<bool> Delete(string id);
    }
}
