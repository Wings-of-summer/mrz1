using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstLabMRZ
{
    public partial class ImageArchiverForm : Form
    {
        public ImageArchiverForm()
        {
            InitializeComponent();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imageBox.Load(openFileDialog1.FileName);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox.Image = null;
        }

        private void compressImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nText = nTextBox.Text;
            string mText = mTextBox.Text;
            string pText = pTextBox.Text;

            if (nText.Equals(String.Empty) && mText.Equals(String.Empty) && pText.Equals(String.Empty)) 
            {
                return;
            }
            
            int n = Int32.Parse(nText);
            int m = Int32.Parse(mText);
            int p = Int32.Parse(pText);

            Image image = imageBox.Image;
            ImageArchiver imageArchiver = new ImageArchiver(image);
            compressedImageBox.Image = imageArchiver.CompressImage(n, m, p);
        }
    }
}
