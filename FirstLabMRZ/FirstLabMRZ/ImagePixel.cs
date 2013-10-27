using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLabMRZ
{
    class ImagePixel
    {
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }

        public ImagePixel(double r, double g, double b) 
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }
    }
}
