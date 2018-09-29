namespace ProductWebApplication.Mappers
{
    using ProductWebApplication.Models;

    public static class ProductMapper
    {
        public static Product MapProduct(ProductViewModel productViewModel)
        {
            var product = new Product
            {
                Image = productViewModel.Image,
                Name = productViewModel.Name,
                Manufacturer = new Manufacturer
                {
                    Id = productViewModel.ManufacturerId
                }
            };

            return product;
        }
    }
}
