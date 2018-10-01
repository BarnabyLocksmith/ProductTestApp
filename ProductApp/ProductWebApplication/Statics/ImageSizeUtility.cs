namespace ProductWebApplication.Statics
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    public class ImageSizeUtility
    {
        public static Image Resize(IFormFile fromFileImage, int maxWidth, int maxHeight)
        {
            var current = Image.FromStream(fromFileImage.OpenReadStream(), true, true);

            int width, height;
            #region reckon size 
            if (current.Width > current.Height)
            {
                width = maxWidth;
                height = Convert.ToInt32(current.Height * maxHeight / (double)current.Width);
            }
            else
            {
                width = Convert.ToInt32(current.Width * maxWidth / (double)current.Height);
                height = maxHeight;
            }
            #endregion

            #region get resized bitmap 
            var canvas = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(canvas))
            {
                //graphics.CompositingQuality = CompositingQuality.HighSpeed;
                //graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.DrawImage(current, 0, 0, width, height);
            }

            return canvas;
            #endregion
        }

        public static byte[] ToByteArray(Image current)
        {
            using (var stream = new MemoryStream())
            {
                current.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
