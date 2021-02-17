using System;
using System.Collections.Generic;
using Item.API.Entities;
using MongoDB.Driver;

namespace Item.API.Data
{
    public class ItemContextSeed
    {
        public static void SeedData(IMongoCollection<Product> collection)
        {
            bool existMeetingRoom = collection.Find(p => true).Any();

            if (!existMeetingRoom)
                collection.InsertManyAsync(GetPreconfiguredProducts());
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product() { Id = "602d62c5eb7a112430e5f790", Name = "Phone", Category = 5,Type = 1 },
                new Product() { Id = "602d62c5eb7a112430e5f780", Name = "Scanner", Category = 6,Type = 0 },
                new Product() { Id = "602d62c5eb7a112430e5f779", Name = "Xbox", Category = 4,Type = 0 },
                new Product() { Id = "602d62c5eb7a112430e5f778", Name = "Desk", Category = 3,Type = 1 },
                new Product() { Id = "602d62b7eb7a112430e5f777", Name = "Table", Category = 2,Type = 1 },
                new Product() { Id = "602d62a5eb7a112430e5f776", Name = "TV", Category = 1,Type = 1 }
            };
        }
    }
}
