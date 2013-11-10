using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLabMRZ
{
    class ImageRectangle
    {
        public ImagePixel[,] PixelsMatrix { get; set; }

        public int N { get; set; }
        public int M { get; set; }

        public ImageRectangle(int n, int m) 
        {
            this.N = n;
            this.M = m;
        }

        public double[] GetVector() 
        {
            double[] vector = new double[N * M * 3];

            int n = 0;

            for (int j = 0; j < N; j++) 
            {
                for (int i = 0; i < M; i++) 
                {
                    ImagePixel pixel = PixelsMatrix[i, j];
                    vector[n] = pixel.R;
                    vector[n + 1] = pixel.G;
                    vector[n + 2] = pixel.B;

                    n += 3;
                }
            }

            return vector;
        }

        public double[,] GetStandartVector()
        {
            double[,] vector = new double[1, N * M * 3];

            int n = 0;

            for (int j = 0; j < N; j++)
            {
                for (int i = 0; i < M; i++)
                {
                    ImagePixel pixel = PixelsMatrix[i, j];
                    vector[0, n] = pixel.R;
                    vector[0, n + 1] = pixel.G;
                    vector[0, n + 2] = pixel.B;

                    n += 3;
                }
            }

            return vector;
        }

        public void SetPixelMatrixFromVector(double[] vector) 
        {
            int n = 0;

            for (int j = 0; j < N; j++)
            {
                for (int i = 0; i < M; i++)
                {
                    ImagePixel pixel = PixelsMatrix[i, j];
                    pixel.R = vector[n];
                    pixel.G = vector[n + 1];
                    pixel.B = vector[n + 2];

                    n += 3;
                }
            }
        }

    }
}
