using System;
using Item.API.Data.Interfaces;
using Item.API.Entities;
using Item.API.Settings;
using MongoDB.Driver;

namespace Item.API.Data
{

    public class ItemContext : IItemContext
    {
        public ItemContext(IItemDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Products = database.GetCollection<Product>(settings.CollectionName);

        }

        public IMongoCollection<Product> Products { get; }
    }
    
}
