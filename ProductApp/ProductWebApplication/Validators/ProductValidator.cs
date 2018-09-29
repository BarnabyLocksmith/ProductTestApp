namespace ProductWebApplication.Validators
{
    using ProductWebApplication.Exceptions;
    using ProductWebApplication.Models;

    public static class ProductValidator
    {
        public static void ValidateProduct(ProductViewModel product)
        {
            if (product.ManufacturerId == null || product.ManufacturerId < 0)
            {
                throw new ProductValidationException("Invalid product property: Manufacturer Id");
            }

            if (string.IsNullOrEmpty(product.Name) || product.Name.Length > 100)
            {
                throw new ProductValidationException($"Invalid product property: Name Value: {product.Name}");
            }
        }
    }
}
