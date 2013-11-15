namespace FirstLabMRZ
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.resultErrorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iteratinResultLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.compressingResultLabel = new System.Windows.Forms.Label();
            this.firstWeightMatrixResult = new System.Windows.Forms.TextBox();
            this.secondWeightMatrixResult = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.iteratinResultLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.resultErrorLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.compressingResultLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.firstWeightMatrixResult, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.secondWeightMatrixResult, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(796, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(120, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Error";
            // 
            // resultErrorLabel
            // 
            this.resultErrorLabel.AutoSize = true;
            this.resultErrorLabel.Location = new System.Drawing.Point(162, 5);
            this.resultErrorLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.resultErrorLabel.Name = "resultErrorLabel";
            this.resultErrorLabel.Size = new System.Drawing.Size(13, 13);
            this.resultErrorLabel.TabIndex = 1;
            this.resultErrorLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(105, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Iteration";
            // 
            // iteratinResultLabel
            // 
            this.iteratinResultLabel.AutoSize = true;
            this.iteratinResultLabel.Location = new System.Drawing.Point(162, 26);
            this.iteratinResultLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.iteratinResultLabel.Name = "iteratinResultLabel";
            this.iteratinResultLabel.Size = new System.Drawing.Size(13, 13);
            this.iteratinResultLabel.TabIndex = 3;
            this.iteratinResultLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(22, 15, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Weight matrix on first layer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 263);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 15, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Weight matrix on second layer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 47);
            this.label8.Margin = new System.Windows.Forms.Padding(60, 5, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Compression ratio";
            // 
            // compressingResultLabel
            // 
            this.compressingResultLabel.AutoSize = true;
            this.compressingResultLabel.Location = new System.Drawing.Point(162, 47);
            this.compressingResultLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.compressingResultLabel.Name = "compressingResultLabel";
            this.compressingResultLabel.Size = new System.Drawing.Size(13, 13);
            this.compressingResultLabel.TabIndex = 9;
            this.compressingResultLabel.Text = "0";
            // 
            // firstWeightMatrixResult
            // 
            this.firstWeightMatrixResult.Location = new System.Drawing.Point(162, 66);
            this.firstWeightMatrixResult.Multiline = true;
            this.firstWeightMatrixResult.Name = "firstWeightMatrixResult";
            this.firstWeightMatrixResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.firstWeightMatrixResult.Size = new System.Drawing.Size(630, 179);
            this.firstWeightMatrixResult.TabIndex = 10;
            this.firstWeightMatrixResult.WordWrap = false;
            // 
            // secondWeightMatrixResult
            // 
            this.secondWeightMatrixResult.Location = new System.Drawing.Point(162, 251);
            this.secondWeightMatrixResult.Multiline = true;
            this.secondWeightMatrixResult.Name = "secondWeightMatrixResult";
            this.secondWeightMatrixResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.secondWeightMatrixResult.Size = new System.Drawing.Size(630, 180);
            this.secondWeightMatrixResult.TabIndex = 11;
            this.secondWeightMatrixResult.WordWrap = false;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 437);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label compressingResultLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label iteratinResultLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label resultErrorLabel;
        private System.Windows.Forms.TextBox firstWeightMatrixResult;
        private System.Windows.Forms.TextBox secondWeightMatrixResult;
    }
}