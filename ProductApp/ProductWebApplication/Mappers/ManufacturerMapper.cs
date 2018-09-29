namespace ProductWebApplication.Mappers
{
    using ProductWebApplication.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ManufacturerMapper
    {
        public static Manufacturer MapManufacturer(ManufacturerViewModel manufacturer)
        {
            return new Manufacturer
            {
                Name = manufacturer.Name,
                Logo = manufacturer.Logo
            };
        }
    }
}
