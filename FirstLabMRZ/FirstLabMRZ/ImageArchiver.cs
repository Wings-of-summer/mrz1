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
        private Image image;

        public ImageArchiver(Image image) 
        {
            this.image = image;
        }

        public Image CompressImage() 
        {
            Bitmap bitmap = image as Bitmap;
            return image;
        }

        private void ConvertPixels(Color[,] pixels, int height, int width) 
        {
            for (int i = 0; i < height; i++) 
            {
                for (int j = 0; j < width; j++) 
                {

                }
            }
        }
    }
}
