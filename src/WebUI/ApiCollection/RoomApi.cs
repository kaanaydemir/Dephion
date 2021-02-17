using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.ApiCollection.Infrastructure;
using WebUI.ApiCollection.Interfaces;
using WebUI.Models;
using WebUI.Settings;

namespace WebUI.ApiCollection
{
    public class RoomApi : BaseHttpClientWithFactory, IRoomApi
    {
        private readonly IApiSettings _settings;

        public RoomApi(IHttpClientFactory factory, IApiSettings settings)
            : base(factory)
        {
            _settings = settings;
        }

        public async Task<RoomModel> GetRoom(string id)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                               .SetPath(_settings.RoomPath)
                               .AddToPath(id)
                               .HttpMethod(HttpMethod.Get)
                               .GetHttpMessage();

            return await SendRequest<RoomModel>(message);
        }

        public async Task<IEnumerable<RoomModel>> GetRooms()
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                               .SetPath(_settings.RoomPath)
                               .HttpMethod(HttpMethod.Get)
                               .GetHttpMessage();

            return await SendRequest<IEnumerable<RoomModel>>(message);
        }

        public async Task<IEnumerable<RoomModel>> GetRoomsByLocation(int location)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                               .SetPath(_settings.RoomPath)
                               .AddToPath("GetMeetingRoomByLocation")
                               .AddToPath(Convert.ToString(location))
                               .HttpMethod(HttpMethod.Get)
                               .GetHttpMessage();

            return await SendRequest<IEnumerable<RoomModel>>(message);
        }
    }
}
