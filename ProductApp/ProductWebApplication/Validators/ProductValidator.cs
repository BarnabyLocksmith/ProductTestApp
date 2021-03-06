﻿namespace ProductWebApplication.Validators
{
    using ProductWebApplication.Exceptions;
    using ProductWebApplication.Models;
    using System;
    using System.Drawing;
    using System.IO;

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

            if (!ImageValidation(product.ImageData))
            {
                throw new ProductValidationException("Invalid product property: Image");
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
