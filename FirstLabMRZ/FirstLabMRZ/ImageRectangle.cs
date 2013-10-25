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
        public double[, ,] ConvertedPixelsMatrix { get; set; }
        public double[] StandardVector { get; set; }

        public int N { get; set; }
        public int M { get; set; }

        public ImageRectangle(int n, int m) 
        {
            this.N = n;
            this.M = m;
        }


    }
}
