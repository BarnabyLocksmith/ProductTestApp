namespace ProductWebApplication.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using ProductWebApplication.Contexts;
    using ProductWebApplication.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductRepository : IProductRepository
    {
        private readonly Context context;

        public ProductRepository(Context context)
        {
            this.context = context;
        }

        public Task<List<Product>> GetProducts()
        {
            return context.Products
                .Include(x => x.Manufacturer)
                .ToListAsync();
        }

        public Task<Product> GetProduct(int id)
        {
            return context.Products.Include(x => x.Manufacturer).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<int> CreateProduct(Product product, Guid userId)
        {
            if (!CheckManufacturerExistency(product.Manufacturer.Id))
            {
                throw new ArgumentException();
            }

            if (!CheckManufacturerExistency(product.Manufacturer.Id))
            {
                throw new ArgumentException();
            }

            product.Manufacturer = GetManufacturer(product.Manufacturer.Id);
            product.CreatedDate = DateTime.UtcNow;
            product.CreatedBy = userId;
            product.UpdatedDate = DateTime.UtcNow;
            product.UpdatedBy = userId;
            context.Add(product);
            return context.SaveChangesAsync();
        }

        public Task<int> ModifyProduct(int id, Product product, Guid userId)
        {
            if (!CheckProductExistency(id))
            {
                throw new ArgumentException();
            }

            if (!CheckManufacturerExistency(product.Manufacturer.Id))
            {
                throw new ArgumentException();
            }

            var originalProduct = context.Products.FirstOrDefaultAsync(x => x.Id == id).Result; // TODO
            originalProduct.Manufacturer = GetManufacturer(product.Manufacturer.Id);
            originalProduct.Name = product.Name;
            originalProduct.Image = product.Image;
            originalProduct.UpdatedDate = DateTime.UtcNow;
            originalProduct.UpdatedBy = userId;
            context.Update(originalProduct);
            return context.SaveChangesAsync();
        }

        public Task<int> DeleteProduct(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            context.Remove(product);
            return context.SaveChangesAsync();
        }

        public bool CheckProductExistency(int id)
        {
            return context.Products.Any(x => x.Id == id);
        }

        private bool CheckManufacturerExistency(int id)
        {
            return context.Manufacturers.Any(x => x.Id == id);
        }

        private Manufacturer GetManufacturer(int id)
        {
            return context.Manufacturers.FirstOrDefault(x => x.Id == id);
        }
    }
}
