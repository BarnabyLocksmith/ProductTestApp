namespace ProductWebApplication.Repositories
{
    using ProductWebApplication.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();

        Task<Product> GetProduct(int id);

        Task<int> CreateProduct(Product product, Guid userId);

        Task<int> ModifyProduct(int id, Product product, Guid userId);

        Task<int> DeleteProduct(int id);

        bool CheckProductExistency(int id);
    }
}
