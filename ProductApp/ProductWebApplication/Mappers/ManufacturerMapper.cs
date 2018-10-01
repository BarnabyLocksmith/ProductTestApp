namespace ProductWebApplication.Mappers
{
    using ProductWebApplication.Models;

    public static class ManufacturerMapper
    {
        public static Manufacturer MapManufacturer(ManufacturerViewModel manufacturer)
        {
            return new Manufacturer
            {
                Name = manufacturer.Name,
                Logo = manufacturer.Logo,
                LogoData = manufacturer.LogoData
            };
        }
    }
}
