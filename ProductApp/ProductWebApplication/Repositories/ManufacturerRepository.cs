namespace ProductWebApplication.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using ProductWebApplication.Contexts;
    using ProductWebApplication.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly Context context;

        public ManufacturerRepository(Context context)
        {
            this.context = context;
        }

        public Task<List<Manufacturer>> GetManufacturers()
        {
            return context.Manufacturers
                .Include(x => x.Products)
                .ToListAsync();
        }

        public Task<Manufacturer> GetManufacturer(int id)
        {
            return context.Manufacturers.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<int> CreateManufacturer(Manufacturer manufacturer, Guid userId)
        {
            manufacturer.CreatedBy = userId;
            manufacturer.CreatedDate = DateTime.UtcNow;
            manufacturer.UpdatedBy = userId;
            manufacturer.UpdatedDate = DateTime.UtcNow;
            context.Add(manufacturer);
            return context.SaveChangesAsync();
        }

        public Task<int> ModifyManufacturer(int id, Manufacturer manufacturer, Guid userId)
        {
            if (!CheckManufacturerExistency(id))
            {
                throw new ArgumentException();
            }

            var originalManufacturer = context.Manufacturers.FirstOrDefaultAsync(x => x.Id == id).Result;
            originalManufacturer.Name = manufacturer.Name;
            originalManufacturer.Logo = manufacturer.Logo;
            originalManufacturer.LogoData = manufacturer.LogoData;
            originalManufacturer.UpdatedBy = userId;
            originalManufacturer.UpdatedDate = DateTime.UtcNow;

            context.Update(originalManufacturer);
            return context.SaveChangesAsync();
        }

        public Task<int> DeleteManufacturer(int id)
        {
            var manufacturer = context.Manufacturers.FirstOrDefault(x => x.Id == id);
            var products = GetProductsForManufacturer(id);

            foreach (var product in products)
            {
                context.Remove(product);
            }

            context.Remove(manufacturer);
            return context.SaveChangesAsync();
        }

        private bool CheckManufacturerExistency(int id)
        {
            return context.Manufacturers.Any(x => x.Id == id);
        }

        private List<Product> GetProductsForManufacturer(int id)
        {
            var products = context.Products
                .Where(x => x.Manufacturer.Id == id)
                .ToList();

            return products;
        }
    }
}
