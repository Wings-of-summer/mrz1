using Meta.Numerics.Matrices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int n;
        private int m;
        private int p;
        private int iterationNumber;
        private double a;
        private double e;

        public CurrentState state { get; set; }

        public class CurrentState
        {
            public double CurentError;
            public int IterationNumber;
            public Image CompressedImage;
        }

        public ImageArchiver(Image image, int n, int m, int p, double a, double e, int iterationNumber) 
        {
            this.image = image;
            this.n = n;
            this.m = m;
            this.p = p;
            this.a = a;
            this.e = e;
            this.iterationNumber = iterationNumber;
        }

        public void CompressImage(BackgroundWorker worker, DoWorkEventArgs doWorkEvent) 
        {
            Bitmap bitmap = image as Bitmap;

            int height = bitmap.Height;
            int width = bitmap.Width;

            ImageRectangle[] rectangles = SplitIntoRectangles(bitmap);

            TeachNeuralNetwork(rectangles, worker, doWorkEvent);

            ImagePixel[,] pixels = AssembleRectanglesToPixelMatrix(rectangles, height, width);

            ConvertPixelsInStandardForm(pixels, height, width);

            Image compressedImage = AssembleImageFromPixels(pixels, height, width);

            state.CompressedImage = compressedImage;

            worker.ReportProgress(0, state);
        }

        private ImageRectangle[] SplitIntoRectangles(Bitmap bitmap) 
        {
            int numberOfRectangels = (bitmap.Height * bitmap.Width) / (n * m);

            ImageRectangle[] pixelsRectangels = new ImageRectangle[numberOfRectangels];

            int xRectanglePosition = 0;
            int yRectanglePosition = 0;

            for (int r = 0; r < numberOfRectangels; r++) 
            {
                ImageRectangle rectangle = new ImageRectangle(n, m);

                rectangle.PixelsMatrix = GetRectanglePixelMatrix(xRectanglePosition, yRectanglePosition, bitmap);

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

        private ImagePixel[,] GetRectanglePixelMatrix(int xRectanglePosition, int yRectanglePosition, Bitmap bitmap)
        {
            Color[,] pixelsMatrix = new Color[m, n];

            for (int i = 0, x = xRectanglePosition * m; i < m; i++, x++)
            {
                for (int j = 0, y = yRectanglePosition * n; j < n; j++, y++)
                {
                    pixelsMatrix[i, j] = bitmap.GetPixel(x, y);
                }
            }

            return GetConvertedPixels(pixelsMatrix);
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

        private ImagePixel[,] GetConvertedPixels(Color[,] pixels) 
        {
            ImagePixel[,] pixelsMatrix = new ImagePixel[m, n];

            for (int i = 0; i < m; i++) 
            {
                for (int j = 0; j < n; j++) 
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
            double value = Math.Abs(C_MAX * (oldValue + 1) / 2);
            return value > C_MAX ? C_MAX : (value < 0 ? 0 : value);
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

        private void TeachNeuralNetwork(ImageRectangle[] rectangles, BackgroundWorker worker, DoWorkEventArgs doWorkEvent)
        {
            int N = m * n * 3;
            double[,] matrix = new double[N, p];

            Random rand = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    matrix[i, j] = rand.NextDouble() * 0.1;
                }
            }

            Matrix weightMatrix = new Matrix(matrix, N, p);

            Matrix secondWeightMatrix = weightMatrix.Transpose();

            double totalError = e + 1;
            int totalIterationNumber = 0;

            state = new CurrentState();

            while (totalError > e && totalIterationNumber < iterationNumber)
            {
                totalError = 0;

                foreach (ImageRectangle rectangle in rectangles)
                {
                    Matrix xVector = new Matrix(rectangle.GetStandartVector(), 1, N);

                    Matrix yVector = xVector.Multiply(weightMatrix);
                    Matrix xSecondVector = yVector.Multiply(secondWeightMatrix);
                    Matrix deltaXVector = xSecondVector.Subtract(xVector);

                    weightMatrix = weightMatrix.Subtract(xVector.Transpose().Multiply(a).Multiply(deltaXVector).Multiply(secondWeightMatrix.Transpose()));
                    secondWeightMatrix = secondWeightMatrix.Subtract(yVector.Transpose().Multiply(a).Multiply(deltaXVector));
                }

                foreach (ImageRectangle rectangle in rectangles)
                {

                    Matrix xVector = new Matrix(rectangle.GetStandartVector(), 1, N);

                    Matrix yVector = xVector.Multiply(weightMatrix);
                    Matrix xSecondVector = yVector.Multiply(secondWeightMatrix);
                    Matrix deltaXVector = xSecondVector.Subtract(xVector);

                    for (int j = 0; j < N; j++)
                    {
                        totalError += deltaXVector.Get(0, j) * deltaXVector.Get(0, j);
                    }
                }

                totalIterationNumber++;

                state.CurentError = totalError;
                state.IterationNumber = totalIterationNumber;
                state.CompressedImage = null;

                worker.ReportProgress(0, state);
            }

            foreach (ImageRectangle rectangle in rectangles)
            {
                Matrix xVector = new Matrix(rectangle.GetStandartVector(), 1, N);

                Matrix yVector = xVector.Multiply(weightMatrix);
                Matrix xSecondVector = yVector.Multiply(secondWeightMatrix);

                rectangle.SetPixelMatrixFromVector(xSecondVector.GetElements());
            }
        }
    }
}
