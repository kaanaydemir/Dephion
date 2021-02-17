using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Item.API.Entities;

namespace Item.API.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string id);
    }
}
