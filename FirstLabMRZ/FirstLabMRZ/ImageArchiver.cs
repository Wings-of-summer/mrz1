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
        private const double C_MAX = 255;
        private Image image;

        public ImageArchiver(Image image) 
        {
            this.image = image;
        }

        public Image CompressImage(int n, int m) 
        {
            Bitmap bitmap = image as Bitmap;

            int height = bitmap.Height;
            int width = bitmap.Width;

            ImageRectangle[] rectangles = SplitIntoRectangles(bitmap, n, m);

            ImagePixel[,] pixels = GetConvertedPixels(GetPixelsMatrix(bitmap), height, width);
            ConvertPixelsInStandardForm(pixels, height, width);

            return AssembleImageFromPixels(pixels, height, width);
        }

        private ImageRectangle[] SplitIntoRectangles(Bitmap bitmap, int n, int m) 
        {
            int numberOfRectangels = Math.Abs((bitmap.Height / n) - (bitmap.Width / m));

            ImageRectangle[] pixelsRectangels = new ImageRectangle[numberOfRectangels];

            int xStart = 0;
            int yStart = 0;

            for (int r = 0; r < numberOfRectangels; r++) 
            {
                ImageRectangle rectangle = new ImageRectangle(n, m);

                Color[,] pixelsMatrix = new Color[m, n];

                for (int i = xStart; i < m; i++, xStart++) 
                {
                    for (int j = yStart; j < n; j++, yStart++) 
                    {
                        pixelsMatrix[i - xStart, j - yStart] = bitmap.GetPixel(i, j);
                    }
                }

                rectangle.PixelsMatrix = GetConvertedPixels(pixelsMatrix, n, m);
                pixelsRectangels[r] = rectangle;
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

        private ImagePixel[,] GetConvertedPixels(Color[,] pixels, int height, int width) 
        {
            ImagePixel[,] pixelsMatrix = new ImagePixel[width, height];

            for (int i = 0; i < width; i++) 
            {
                for (int j = 0; j < height; j++) 
                {
                    pixelsMatrix[i, j] = GetConvertedPixel(pixels, i, j);
                }
            }

            return pixelsMatrix;
        }

        private ImagePixel GetConvertedPixel(Color[,] pixels, int i, int j) 
        {
            double r = pixels[i, j].R;
            double g = pixels[i, j].G;
            double b = pixels[i, j].B;

            ImagePixel pixel = new ImagePixel(Convert(r), Convert(g), Convert(b));

            return pixel;
        }

        private double Convert(double oldValue) 
        {
            return (2 * oldValue / C_MAX) - 1;
        }

        private void ConvertPixelsInStandardForm(ImagePixel[,] pixels, int height, int width)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    ConvertPixelInStandardForm(pixels[i, j]);
                }
            }
        }

        private void ConvertPixelInStandardForm(ImagePixel pixel)
        {
            pixel.R = ConvertToStandardForm(pixel.R);
            pixel.G = ConvertToStandardForm(pixel.G);
            pixel.B = ConvertToStandardForm(pixel.B);
        }

        private double ConvertToStandardForm(double oldValue)
        {
            return (oldValue + 1) * C_MAX / 2;
        }

        private Image AssembleImageFromPixels(ImagePixel[,] pixels, int height, int width) 
        {
            Bitmap bitmap = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    ImagePixel pixel = pixels[i, j];
                    Color color = Color.FromArgb((Int32)pixel.R, (Int32)pixel.G, (Int32)pixel.B);
                    bitmap.SetPixel(i, j, color);
                }
            }

            return bitmap as Image;
        }

        private ImagePixel[,] AssembleRectanglesToPixelMatrix(ImageRectangle[] pixelsRectangels, int height, int width) 
        {
            ImagePixel[,] pixels = new ImagePixel[width, height];

            int startI = 0;
            int startJ = 0;

            for (int p = 0; p < pixelsRectangels.Length; p++) 
            {
                if (startI == width) 
                {

                }

                ImageRectangle rectangle = pixelsRectangels[p];
                ImagePixel[,] rectanglePixels = rectangle.PixelsMatrix;
                for (int m = 0, i = startI; m < rectangle.M; m++, i++) 
                {
                    for (int n = 0, j = startJ; n < rectangle.N; n++, j++) 
                    {
                        pixels[i, j] = rectanglePixels[m, n];
                    }
                }
            }

            return pixels;
        }
    }
}
