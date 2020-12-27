using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Utilities
{
    class ImageTools
    {
        public static Image getSqureSizedImage(Image originalImage)
        {
            int smallestDimension = Math.Min(originalImage.Height, originalImage.Width);
            Size squareImageSize = new Size(smallestDimension, smallestDimension);
            Bitmap squareSizedImage = new Bitmap(squareImageSize.Width, squareImageSize.Height);
            using (Graphics graphics = Graphics.FromImage(squareSizedImage))
            {
                graphics.FillRectangle(Brushes.White, 0, 0, squareImageSize.Width, squareImageSize.Height);
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(originalImage, (squareImageSize.Width / 2) - (originalImage.Width / 2), (squareImageSize.Height / 2) - (originalImage.Height / 2), originalImage.Width, originalImage.Height);
            }
            return Resize(squareSizedImage, 200, 200);
        }

        public static Bitmap Resize(Image image, int width, int height)
        {

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static byte[] getByteArrayFromImage(Image image)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                image.Save(mStream, System.Drawing.Imaging.ImageFormat.Bmp  );
                return mStream.ToArray();
            }
        }

        public static Image getImageFromByteArray(byte[] imageBytes)
        {
            using (MemoryStream mStream = new MemoryStream(imageBytes))
            {
                return Image.FromStream(mStream);
            }
        }
    }
}
