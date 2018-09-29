namespace ProductWebApplication.DataServiceClients
{
    using Newtonsoft.Json;
    using ProductWebApplication.Models;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class DataServiceClient : IDataServiceClient
    {
        private readonly HttpClient client;
        private readonly string BaseUrl;

        public DataServiceClient()
        {
            this.client = new HttpClient();
            this.BaseUrl = "https://bimobjectwebapplication.azurewebsites.net"; // TODO This has to move out to the configuration file
        }

        // Products
        public async Task<HttpResponseMessage> CreateProduct(ProductViewModel product)
        {
            var response = await client.PostAsync(
                        $"{BaseUrl}/api/Product",
                         new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            return response;
        }

        public async Task<List<Product>> GetProducts()
        {
            var response = await client.GetAsync($"{BaseUrl}/api/Product");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseBody);

            return products;
        }

        public async Task<Product> GetProduct(int id)
        {
            var response = await client.GetAsync($"{BaseUrl}/api/Product/{id}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Product product = JsonConvert.DeserializeObject<Product>(responseBody);

            return product;
        }

        public async Task<HttpResponseMessage> ModifyProduct(int id, ProductViewModel product)
        {
            var response = await client.PutAsync(
                        $"{BaseUrl}/api/Product/{id}",
                         new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            return response;
        }

        public async Task<HttpResponseMessage> DeleteProduct(int id)
        {
            var response = await client.DeleteAsync($"{BaseUrl}/api/Product/{id}");
            response.EnsureSuccessStatusCode();

            return response;
        }

        // Manufacturers
        public async Task<HttpResponseMessage> CreateManufacturer(ManufacturerViewModel manufacturer)
        {
            var response = await client.PostAsync(
                        $"{BaseUrl}/api/Manufacturer",
                         new StringContent(JsonConvert.SerializeObject(manufacturer), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            return response;
        }

        public async Task<List<Manufacturer>> GetManufacturers()
        {
            var response = await client.GetAsync($"{BaseUrl}/api/Manufacturer");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Manufacturer> manufacturers = JsonConvert.DeserializeObject<List<Manufacturer>>(responseBody);

            return manufacturers;
        }

        public async Task<Manufacturer> GetManufacturer(int id)
        {
            var response = await client.GetAsync($"{BaseUrl}/api/Manufacturer/{id}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Manufacturer manufacturer = JsonConvert.DeserializeObject<Manufacturer>(responseBody);

            return manufacturer;
        }

        public async Task<HttpResponseMessage> ModifyManufacturer(int id, ManufacturerViewModel manufacturer)
        {
            var response = await client.PutAsync(
                        $"{BaseUrl}/api/Manufacturer/{id}",
                         new StringContent(JsonConvert.SerializeObject(manufacturer), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            return response;
        }

        public async Task<HttpResponseMessage> DeleteManufacturer(int id)
        {
            var response = await client.DeleteAsync($"{BaseUrl}/api/Manufacturer/{id}");
            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
