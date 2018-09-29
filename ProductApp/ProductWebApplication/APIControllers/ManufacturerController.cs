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
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerRepository manufacturerRepository;
        private readonly Guid userId = StaticUser.GetUserId();

        public ManufacturerController(IManufacturerRepository manufacturerRepository)
        {
            this.manufacturerRepository = manufacturerRepository;
        }

        // GET: api/Manufacturer
        [HttpGet]
        public Task<List<Manufacturer>> Get()
        {
            return manufacturerRepository.GetManufacturers();
        }

        // GET: api/Manufacturer/5
        [HttpGet("{id}")]
        public Task<Manufacturer> Get(int id)
        {
            return manufacturerRepository.GetManufacturer(id);
        }

        // POST: api/Manufacturer
        [HttpPost]
        public Task<int> Post(ManufacturerViewModel manufacturer)
        {
            ManufacturerValidator.ValidateManufacturer(manufacturer);
            var mappedManufacturer = ManufacturerMapper.MapManufacturer(manufacturer);
            return manufacturerRepository.CreateManufacturer(mappedManufacturer, this.userId);
        }

        // PUT: api/Manufacturer/5
        [HttpPut("{id}")]
        public Task<int> Put(int id, ManufacturerViewModel manufacturer)
        {
            ManufacturerValidator.ValidateManufacturer(manufacturer);
            var mappedManufacturer = ManufacturerMapper.MapManufacturer(manufacturer);
            return manufacturerRepository.ModifyManufacturer(id, mappedManufacturer, this.userId);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Task<int> Delete(int id)
        {
            return manufacturerRepository.DeleteManufacturer(id);
        }
    }
}
