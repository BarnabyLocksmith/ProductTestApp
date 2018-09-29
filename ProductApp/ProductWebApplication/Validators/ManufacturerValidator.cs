namespace ProductWebApplication.Validators
{
    using ProductWebApplication.Exceptions;
    using ProductWebApplication.Models;

    public class ManufacturerValidator
    {
        public static void ValidateManufacturer(ManufacturerViewModel manufacturer)
        {
            if (string.IsNullOrEmpty(manufacturer.Name) || manufacturer.Name.Length > 100)
            {
                throw new ManufacturerValidationException($"Invalid manufacturer property: Name. Value: {manufacturer.Name}");
            }
        }
    }
}
