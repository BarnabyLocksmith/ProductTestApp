namespace ProductWebApplication.APIControllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ProductWebApplication.Mappers;
    using ProductWebApplication.Models;
    using ProductWebApplication.Repositories;
    using ProductWebApplication.Statics;
    using ProductWebApplication.Validators;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly Guid userId = StaticUser.GetUserId();

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET: api/Product
        [HttpGet]
        public Task<List<Product>> Get()
        {
            return productRepository.GetProducts();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public Task<Product> Get(int id)
        {
            return productRepository.GetProduct(id);
        }

        // POST: api/Product
        [HttpPost]
        public Task<int> Post(ProductViewModel product)
        {
            ProductValidator.ValidateProduct(product);
            var mappedProduct = ProductMapper.MapProduct(product);
            return productRepository.CreateProduct(mappedProduct, this.userId);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public Task<int> Put(int id, ProductViewModel product)
        {
            ProductValidator.ValidateProduct(product);
            var mappedProduct = ProductMapper.MapProduct(product);
            return productRepository.ModifyProduct(id, mappedProduct, this.userId);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Task<int> Delete(int id)
        {
            return productRepository.DeleteProduct(id);
        }
    }
}
