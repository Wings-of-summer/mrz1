using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstLabMRZ;
using System.IO;
using System.ComponentModel;
using System.Drawing;

namespace FirstLabTest
{
    [TestClass]
    public class FirstTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            FirstChartTest();
            SecondChartTest();
            ThirdChartTest();
        }

        private void FirstChartTest() 
        {
            int n = 8;
            int m = 8;
            int iteration = Int32.MaxValue;
            double a = 0.0005;
            double e = 1550;

            int[] pValues = new int[]{
                24, 26, 28, 30, 34, 36, 40, 42, 44, 46, 52, 58, 64,
                70, 76, 82, 88, 94, 100, 105, 110, 115, 120, 125, 130,  135, 140, 145, 150, 155, 160, 170, 180, 192
            };

            string parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            string imagePath = parentPath + @"\Images\cat256.jpg";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(parentPath + @"\Results\test1.txt", false))
            {
                file.WriteLine("Compressing:       Iteration:");
            } 

            foreach (int p in pValues) 
            {
                ImageArchiver imageArchiver = new ImageArchiver(Image.FromFile(imagePath), n, m, p, a, e, iteration);
                imageArchiver.CompressImage(new BackgroundWorker(), new DoWorkEventArgs(new object()), true);

                double compressing = imageArchiver.state.Compressing;
                double iterationNumber = imageArchiver.state.IterationNumber;

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(parentPath + @"\Results\test1.txt", true))
                {
                    file.WriteLine(compressing.ToString() + "  " + iterationNumber.ToString());
                } 
            }
        }

        private void SecondChartTest()
        {
            int n = 8;
            int m = 8;
            int iteration = Int32.MaxValue;
            double a = 0.0005;
            int p = 24;

            double[] eValues = new double[]{
                        1550, 1555, 1560, 1575, 1590, 1615, 1650, 1680, 1720, 1750, 1790, 1870, 1980, 2100, 2300, 2525, 2575, 2625, 2725,
                        2825, 2925,  3025, 3125, 3225, 3325, 3425, 3525, 3625, 3725, 3825, 3925, 4025, 4125, 4225, 4325, 4425, 4525, 4625,
                        4725, 5000, 5500, 6000, 7000
                    };

            string parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            string imagePath = parentPath + @"\Images\cat256.jpg";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(parentPath + @"\Results\test2.txt", false))
            {
                file.WriteLine("Error:       Iteration:");
            }

            foreach (int e in eValues)
            {
                ImageArchiver imageArchiver = new ImageArchiver(Image.FromFile(imagePath), n, m, p, a, e, iteration);
                imageArchiver.CompressImage(new BackgroundWorker(), new DoWorkEventArgs(new object()), true);

                double error = imageArchiver.state.CurentError;
                double iterationNumber = imageArchiver.state.IterationNumber;

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(parentPath + @"\Results\test2.txt", true))
                {
                    file.WriteLine(error.ToString() + "  " + iterationNumber.ToString());
                }
            }
        }

        private void ThirdChartTest()
        {
            int n = 8;
            int m = 8;
            int iteration = Int32.MaxValue;
            double e = 1550;
            int p = 24;

            double[] aValues = new double[]{
                0.005, 0.0045, 0.004, 0.0035, 0.003, 0.0025, 0.002, 0.0015, 0.001, 0.00095, 0.0009, 0.00085, 0.0008, 0.00075,
                0.0007, 0.00065, 0.0006, 0.00055, 0.0005, 0.0004, 0.0003, 0.0002, 0.0001, 0.00009, 0.00008, 0.00007, 0.00006,
                0.00005, 0.00004, 0.00003, 0.00002, 0.00001
            };

            string parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            string imagePath = parentPath + @"\Images\cat256.jpg";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(parentPath + @"\Results\test3.txt", false))
            {
                file.WriteLine("Factor:       Iteration:");
            }

            foreach (int a in aValues)
            {
                ImageArchiver imageArchiver = new ImageArchiver(Image.FromFile(imagePath), n, m, p, a, e, iteration);
                imageArchiver.CompressImage(new BackgroundWorker(), new DoWorkEventArgs(new object()), true);

                double iterationNumber = imageArchiver.state.IterationNumber;

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(parentPath + @"\Results\test3.txt", true))
                {
                    file.WriteLine(a.ToString() + "  " + iterationNumber.ToString());
                }
            }
        }
    }
}
