using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebUI.ApiCollection.Infrastructure;
using WebUI.ApiCollection.Interfaces;
using WebUI.Models;
using WebUI.Settings;

namespace WebUI.ApiCollection
{
    public class ReservationApi : BaseHttpClientWithFactory, IReservationApi
    {

        private readonly IApiSettings _settings;

        public ReservationApi(IHttpClientFactory factory, IApiSettings settings)
        : base(factory)
        {
            _settings = settings;
        }

        public async Task<ReservationModel> CreateReservation(ReservationModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                .SetPath(_settings.ReservationPath)
                                .HttpMethod(HttpMethod.Post)
                                .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<ReservationModel>(message);
        }

        public async Task<IEnumerable<ReservationModel>> GetReservations()
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                               .SetPath(_settings.ReservationPath)
                               .HttpMethod(HttpMethod.Get)
                               .GetHttpMessage();

            return await SendRequest<IEnumerable<ReservationModel>>(message);
        }
    }
}
