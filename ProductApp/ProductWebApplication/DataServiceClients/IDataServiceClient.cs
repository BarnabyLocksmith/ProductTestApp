namespace ProductWebApplication.DataServiceClients
{
    using ProductWebApplication.Models;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IDataServiceClient
    {
        Task<HttpResponseMessage> CreateProduct(ProductViewModel product);
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<HttpResponseMessage> ModifyProduct(int id, ProductViewModel product);
        Task<HttpResponseMessage> DeleteProduct(int id);

        Task<HttpResponseMessage> CreateManufacturer(ManufacturerViewModel manufacturer);
        Task<List<Manufacturer>> GetManufacturers();
        Task<Manufacturer> GetManufacturer(int id);
        Task<HttpResponseMessage> ModifyManufacturer(int id, ManufacturerViewModel product);
        Task<HttpResponseMessage> DeleteManufacturer(int id);
    }
}