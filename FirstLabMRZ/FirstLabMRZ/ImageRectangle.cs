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

    }
}
