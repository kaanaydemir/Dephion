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
    public class ItemApi : BaseHttpClientWithFactory,IItemApi
    {

        private readonly IApiSettings _settings;

        public ItemApi(IHttpClientFactory factory, IApiSettings settings)
            : base(factory)
        {
            _settings = settings;
        }

        public async Task<ItemModel> GetItem(string id)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                               .SetPath(_settings.ItemPath)
                               .AddToPath(id)
                               .HttpMethod(HttpMethod.Get)
                               .GetHttpMessage();

            return await SendRequest<ItemModel>(message);
        }

        public async Task<IEnumerable<ItemModel>> GetItems()
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                               .SetPath(_settings.ItemPath)
                               .HttpMethod(HttpMethod.Get)
                               .GetHttpMessage();

            return await SendRequest<IEnumerable<ItemModel>>(message);
        }
    }
}
