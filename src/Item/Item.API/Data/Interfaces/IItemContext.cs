using System;
using MongoDB.Driver;
using Item.API.Entities;

namespace Item.API.Data.Interfaces
{
    public interface IItemContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
