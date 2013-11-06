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
            StartThread();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) 
            {
                MessageBox.Show("Error: " + e.Error.Message);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ImageArchiver.CurrentState state = (ImageArchiver.CurrentState)e.UserState;
            if (state.CompressedImage != null) 
            {
                compressedImageBox.Image = state.CompressedImage;
            }
            errorLabel.Text = state.CurentError.ToString();
            iterationLabel.Text = state.IterationNumber.ToString();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string nText = nTextBox.Text;
            string mText = mTextBox.Text;
            string pText = pTextBox.Text;
            string aText = aTextBox.Text;
            string eText = eTextBox.Text;
            string iterationNumberText = iterationNumberTextBox.Text;

            if (nText.Equals(String.Empty) || mText.Equals(String.Empty) || pText.Equals(String.Empty) || aText.Equals(String.Empty) || eText.Equals(String.Empty) || iterationNumberText.Equals(String.Empty))
            {
                return;
            }

            int n = Int32.Parse(nText);
            int m = Int32.Parse(mText);
            int p = Int32.Parse(pText);
            int iterationNumber = Int32.Parse(iterationNumberText);
            double a = Double.Parse(aText);
            double error = Double.Parse(eText);

            ImageArchiver imageArchiver = (ImageArchiver)e.Argument;

            imageArchiver.CompressImage(n, m, p, a, error, iterationNumber, backgroundWorker, e);
        }

        private void StartThread()
        {
            Image image = imageBox.Image;
            ImageArchiver imageArchiver = new ImageArchiver(image);

            backgroundWorker.RunWorkerAsync(imageArchiver);
        }
    }
}
