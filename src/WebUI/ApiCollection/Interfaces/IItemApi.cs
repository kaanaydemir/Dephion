using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ApiCollection.Interfaces
{
    public interface IItemApi
    {
        Task<IEnumerable<ItemModel>> GetItems();
        Task<ItemModel> GetItem(string id);
    }
}
