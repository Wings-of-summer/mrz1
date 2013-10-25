using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLabMRZ
{
    class ImageArchiver
    {
        private const double cMax = 255;
        private Image image;

        public ImageArchiver(Image image) 
        {
            this.image = image;
        }

        public Image CompressImage(int n, int m) 
        {
            Bitmap bitmap = image as Bitmap;

            ImageRectangle[] rectangles = SplitIntoRectangles(bitmap, n, m);

            return image;
        }

        private ImageRectangle[] SplitIntoRectangles(Bitmap bitmap, int n, int m) 
        {
            int numberOfRectangels = Math.Abs((bitmap.Height / n) - (bitmap.Width / m));

            ImageRectangle[] pixelsRectangels = new ImageRectangle[numberOfRectangels];

            Color[,] pixelsMatrix = new Color[m, n];

            for (int r = 0; r < numberOfRectangels; r++) 
            {
                ImageRectangle rectangle = new ImageRectangle(n, m);
                for (int i = 0; i < m; i++) 
                {
                    for (int j = 0; j < n; j++) 
                    {
                        pixelsMatrix[m, n] = bitmap.GetPixel(m, n);
                    }
                }

                rectangle.ConvertedPixelsMatrix = ConvertPixels(pixelsMatrix, n, m);
            }

            return pixelsRectangels;
        }

        private Color[,] GetPixelsMatrix(Bitmap bitmap) 
        {
            Color[,] pixelsMatrix = new Color[bitmap.Width, bitmap.Height];

            for (int i = 0; i < bitmap.Width; i++) 
            {
                for (int j = 0; j < bitmap.Height; j++) 
                {
                    pixelsMatrix[i, j] = bitmap.GetPixel(i, j);
                }
            }

            return pixelsMatrix;
        }

        private double[, ,] ConvertPixels(Color[,] pixels, int height, int width) 
        {
            double[,,] convertedPixelsMatrix = new double[width, height, 3];

            for (int i = 0; i < width; i++) 
            {
                for (int j = 0; j < height; j++) 
                {
                    double r = pixels[i, j].R;
                    double g = pixels[i, j].G;
                    double b = pixels[i, j].B;

                    convertedPixelsMatrix[i, j, 0] = (2 * r / cMax) - 1;
                    convertedPixelsMatrix[i, j, 1] = (2 * g / cMax) - 1;
                    convertedPixelsMatrix[i, j, 2] = (2 * b / cMax) - 1;
                }
            }

            return convertedPixelsMatrix;
        }
    }
}
