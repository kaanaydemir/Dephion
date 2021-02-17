using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Item.API.Data.Interfaces;
using Item.API.Entities;
using Item.API.Repositories.Interfaces;
using MongoDB.Driver;

namespace Item.API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IItemContext _context;

        public ItemRepository(IItemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context
                            .Products
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _context
                            .Products
                            .Find(p => p.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task Create(Product product)
        {
            await _context
                    .Products
                    .InsertOneAsync(product);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .Products
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                    && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> Update(Product product)
        {
            var updateResult = await _context
                                        .Products
                                        .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
