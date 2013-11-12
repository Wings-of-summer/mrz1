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
    public partial class ResultForm : Form
    {
        public ResultForm(string error, string iteration, string firstWeightMatrix, string secondWeightMatrix, string compressing)
        {
            InitializeComponent();
            resultErrorLabel.Text = error;
            iteratinResultLabel.Text = iteration;
            firstWeightMatrixResult.Text = firstWeightMatrix;
            secondWeightMatrixResult.Text = secondWeightMatrix;
            compressingResultLabel.Text = compressing;
        }
    }
}
