namespace ProductWebApplication.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ProductWebApplication.Models;

    public interface IManufacturerRepository
    {
        Task<int> CreateManufacturer(Manufacturer manufacturer, Guid userId);
        Task<int> DeleteManufacturer(int id);
        Task<Manufacturer> GetManufacturer(int id);
        Task<List<Manufacturer>> GetManufacturers();
        Task<int> ModifyManufacturer(int id, Manufacturer manufacturer, Guid userId);
    }
}