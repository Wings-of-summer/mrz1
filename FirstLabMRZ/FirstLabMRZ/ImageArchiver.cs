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

            double[] v = rectangles[0].GetVector();

            ImagePixel[,] pixels = AssembleRectanglesToPixelMatrix(rectangles, height, width);

            ConvertPixelsInStandardForm(pixels, height, width);

            return AssembleImageFromPixels(pixels, height, width);
        }

        private ImageRectangle[] SplitIntoRectangles(Bitmap bitmap, int n, int m) 
        {
            int numberOfRectangels = (bitmap.Height * bitmap.Width) / (n * m);

            ImageRectangle[] pixelsRectangels = new ImageRectangle[numberOfRectangels];

            int xRectanglePosition = 0;
            int yRectanglePosition = 0;

            for (int r = 0; r < numberOfRectangels; r++) 
            {
                ImageRectangle rectangle = new ImageRectangle(n, m);

                rectangle.PixelsMatrix = GetRectanglePixelMatrix(n, m, xRectanglePosition, yRectanglePosition, bitmap);

                if (xRectanglePosition >= (bitmap.Width / m) - 1)
                {
                    xRectanglePosition = 0;
                    yRectanglePosition++;
                }
                else 
                {
                    xRectanglePosition++;
                }

                pixelsRectangels[r] = rectangle;
            }

            return pixelsRectangels;
        }

        private ImagePixel[,] GetRectanglePixelMatrix(int n, int m, int xRectanglePosition, int yRectanglePosition, Bitmap bitmap)
        {
            Color[,] pixelsMatrix = new Color[m, n];

            for (int i = 0, x = xRectanglePosition * m; i < m; i++, x++)
            {
                for (int j = 0, y = yRectanglePosition * n; j < n; j++, y++)
                {
                    pixelsMatrix[i, j] = bitmap.GetPixel(x, y);
                }
            }

            return GetConvertedPixels(pixelsMatrix, n, m);
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
            if (pixel == null) 
            {
                pixel = new ImagePixel(0, 0, 0);
                return;
            }
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
                    if (pixel == null) 
                    {
                        pixel = new ImagePixel(0, 0, 0);
                    }
                    Color color = Color.FromArgb((Int32)pixel.R, (Int32)pixel.G, (Int32)pixel.B);
                    bitmap.SetPixel(i, j, color);
                }
            }

            return bitmap as Image;
        }

        private ImagePixel[,] AssembleRectanglesToPixelMatrix(ImageRectangle[] pixelsRectangels, int height, int width) 
        {
            ImagePixel[,] pixels = new ImagePixel[width, height];

            int xRectanglePosition = 0;
            int yRectanglePosition = 0;

            for (int p = 0; p < pixelsRectangels.Length; p++) 
            {
                ImageRectangle rectangle = pixelsRectangels[p];

                AddRectanglePixelsInmatrix(pixels, rectangle, xRectanglePosition, yRectanglePosition);

                if (xRectanglePosition >= (width / rectangle.M) - 1)
                {
                    xRectanglePosition = 0;
                    yRectanglePosition++;
                }
                else
                {
                    xRectanglePosition++;
                }
            }

            return pixels;
        }

        private void AddRectanglePixelsInmatrix(ImagePixel[,] pixels, ImageRectangle rectangle, int xRectanglePosition, int yRectanglePosition) 
        {
            ImagePixel[,] rectanglePixels = rectangle.PixelsMatrix;

            for (int m = 0, i = xRectanglePosition * rectangle.M; m < rectangle.M; m++, i++) 
            {
                for (int n = 0, j = yRectanglePosition * rectangle.N; n < rectangle.N; n++, j++) 
                {
                    pixels[i, j] = rectanglePixels[m, n];
                }
            }
        }
    }
}
