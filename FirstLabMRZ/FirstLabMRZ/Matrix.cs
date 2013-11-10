using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLabMRZ
{
    class Matrix
    {
        private double[,] elements;

        public int Height { get; set; }
        public int Width { get; set; }

        public Matrix(double[,] elements, int height, int width)
        {
            this.elements = elements;
            this.Height = height;
            this.Width = width;
        }

        public double Get(int i, int j)
        {
            return elements[i,j];
        }

        public double[] GetElements()
        {
            double[] elementsVector = new double[Width * Height];

            int k = 0;

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    elementsVector[k] = elements[j, i];
                    k++;
                }
            }

            return elementsVector;
        }

        public Matrix Transpose() {

            double[,] transposedElements = new double[Width, Height];

            for (int i = 0; i < Width; i++) {
                for (int j = 0; j < Height; j++) {
                    transposedElements[i, j] = elements[j, i];
                }
            }

            return new Matrix(transposedElements, Width, Height);
        }

        public Matrix Multiply(Matrix matrix) {

            double[,] resultElements = new double[Height, matrix.Width];

            for (int i = 0; i < Height; i++) {
                for (int j = 0; j < matrix.Width; j++) {
                    for (int k = 0; k < Width; k++) {
                        resultElements[i, j] += elements[i, k] * matrix.Get(k, j);
                    }
                }
            }

            return new Matrix(resultElements, Height, matrix.Width);
        }

        public Matrix Multiply(double value)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    elements[i, j] *= value;
                }
            }
            return this;
        }

        public Matrix Subtract(Matrix matrix)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    elements[i, j] -= matrix.Get(i, j);
                }
            }
            return this;
        }

        public Matrix Add(Matrix matrix)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    elements[i, j] += matrix.Get(i, j);
                }
            }
            return this;
        }

    }
}
