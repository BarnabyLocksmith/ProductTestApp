namespace ProductWebApplicationUnitTests
{
    using ProductWebApplication.Mappers;
    using ProductWebApplication.Models;
    using System;
    using Xunit;

    public class MapperTests
    {
        [Theory]
        [InlineData("Name1", "Image1", 1)]
        [InlineData("", "Image1", 1)]
        [InlineData("Name1", "", 1)]
        [InlineData("Name1", "Image1", null)]
        public void ProductMapperTest_EnsureNoDataChangesMadeByMapper(string Name, string Image, int ManufacturerId)
        {
            var expected = new Product
            {
                Name = Name,
                Image = Image,
                Manufacturer = new Manufacturer
                {
                    Id = ManufacturerId
                }
            };

            var actual = ProductMapper.MapProduct(new ProductViewModel
            {
                Name = Name,
                Image = Image,
                ManufacturerId = ManufacturerId
            });

            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Image, actual.Image);
            Assert.Equal(expected.Manufacturer.Id, actual.Manufacturer.Id);
        }

        [Theory]
        [InlineData("Name1", "Logo1")]
        [InlineData("", "Logo1")]
        [InlineData("Name1", "")]
        public void ManufacturerMapperTest_EnsureNoDataChangesMadeByMapper(string Name, string Logo)
        {
            var expected = new Manufacturer
            {
                Name = Name,
                Logo = Logo
            };

            var actual = ManufacturerMapper.MapManufacturer(new ManufacturerViewModel
            {
                Name = Name,
                Logo = Logo
            });

            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Logo, actual.Logo);
        }
    }
}
