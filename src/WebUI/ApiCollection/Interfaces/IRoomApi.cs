using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ApiCollection.Interfaces
{
    public interface IRoomApi
    {
        Task<IEnumerable<RoomModel>> GetRooms();
        Task<IEnumerable<RoomModel>> GetRoomsByLocation(int location);
        Task<RoomModel> GetRoom(string id);

    }
}
