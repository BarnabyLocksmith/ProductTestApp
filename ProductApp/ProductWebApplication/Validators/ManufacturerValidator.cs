namespace ProductWebApplication.Validators
{
    using ProductWebApplication.Exceptions;
    using ProductWebApplication.Models;
    using System;
    using System.Drawing;
    using System.IO;

    public class ManufacturerValidator
    {
        public static void ValidateManufacturer(ManufacturerViewModel manufacturer)
        {
            if (string.IsNullOrEmpty(manufacturer.Name) || manufacturer.Name.Length > 100)
            {
                throw new ManufacturerValidationException($"Invalid manufacturer property: Name. Value: {manufacturer.Name}");
            }

            if (!ImageValidation(manufacturer.LogoData))
            {
                throw new ManufacturerValidationException("Invalid manufacturer property: Logo");
            }
        }

        private static bool ImageValidation(byte[] image)
        {
            if (image != null)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(image))
                    {
                        var convertedImage = Image.FromStream(ms);
                        if (convertedImage.Size.Height > 250 || convertedImage.Size.Width > 250)
                        {
                            return false;
                        }
                    }
                }
                catch (ArgumentException)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
