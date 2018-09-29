namespace ProductWebApplicationUnitTests
{
    using ProductWebApplication.Exceptions;
    using ProductWebApplication.Models;
    using ProductWebApplication.Validators;
    using Xunit;

    public class ValidatorTests
    {
        [Theory]
        [InlineData("Name1", "Image1", 1)]
        [InlineData("123", "Image1", 1)]
        [InlineData("Name1", "Image1", 53)]
        [InlineData("$|Äˇˇ^^˘˘", "Image1", 53)]
        public void ProductValidatorTests_ValidProduct(string Name, string Image, int ManufacturerId)
        {
            var testProduct = new ProductViewModel
            {
                Image = Image,
                Name = Name,
                ManufacturerId = ManufacturerId
            };

            ProductValidator.ValidateProduct(testProduct);
        }

        [Theory]
        [InlineData("", "Image1", 1)]
        [InlineData("123", "Image1", -1)]
        [InlineData("longnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongname", "Image1", 53)]
        public void ProductValidatorTests_InvalidProduct(string Name, string Image, int ManufacturerId)
        {
            var testProduct = new ProductViewModel
            {
                Image = Image,
                Name = Name,
                ManufacturerId = ManufacturerId
            };

            Assert.Throws<ProductValidationException>(() => ProductValidator.ValidateProduct(testProduct));
        }

        [Theory]
        [InlineData("Name1", "Logo1")]
        [InlineData("@{&161âù|♀'", "Logo1")]
        [InlineData("¢0═", "¢0═")]
        public void ManufacturerValidationTests_ValidManufacturer(string Name, string Logo)
        {
            var testManufacturer = new ManufacturerViewModel
            {
                Name = Name,
                Logo = Logo
            };

            ManufacturerValidator.ValidateManufacturer(testManufacturer);
        }

        [Theory]
        [InlineData("", "Logo1")]
        [InlineData("longnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongnamelongname", "Logo1")]
        public void ManufacturerValidationTests_InvalidManufacturer(string Name, string Logo)
        {
            var testManufacturer = new ManufacturerViewModel
            {
                Name = Name,
                Logo = Logo
            };

            Assert.Throws<ManufacturerValidationException>(() => ManufacturerValidator.ValidateManufacturer(testManufacturer));
        }
    }
}
