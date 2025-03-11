using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LB4.Task_4
{
    internal class Matrix(int _rows, int _colums)
    {
        public int[,] array = new int[_colums, _rows];

        public int Rows { get; } = _rows;
        public int Colums { get; } = _colums;

        public void GenMatrixValue()
        {
            Random rand = new Random();

            for (int i = 0; i < Colums; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    array[i, j] = rand.Next(1, 1000);
                }
            }
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            for (int i = 0; i < matrix1.Colums; i++)
            {
                for (int j = 0; j < matrix1.Rows; j++)
                {
                    matrix1.array[i,j] += matrix2.array[i,j];
                }
            }

            return matrix1;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            for (int i = 0; i < matrix1.Colums; i++)
            {
                for (int j = 0; j < matrix1.Rows; j++)
                {
                    matrix1.array[i, j] -= matrix2.array[i, j];
                }
            }

            return matrix1;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            for (int i = 0; i < matrix1.Colums; i++)
            {
                for (int j = 0; j < matrix1.Rows; j++)
                {
                    matrix1.array[i, j] *= matrix2.array[i, j];
                }
            }

            return matrix1;
        }

        public static Matrix operator *(Matrix matrix1, int value)
        {
            for (int i = 0; i < matrix1.Colums; i++)
            {
                for (int j = 0; j < matrix1.Rows; j++)
                {
                    matrix1.array[i, j] *= value;
                }
            }

            return matrix1;
        }


        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            for (int i = 0; i < matrix1.Colums; i++)
            {
                for (int j = 0; j < matrix1.Rows; j++)
                {
                    if(matrix1.array[i, j] != matrix2.array[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            for (int i = 0; i < matrix1.Colums; i++)
            {
                for (int j = 0; j < matrix1.Rows; j++)
                {
                    if (matrix1.array[i, j] != matrix2.array[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {
            string matrix = "";

            for (int i = 0; i < Colums; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    matrix += array[i, j].ToString() + " ";
                }
            }

            return matrix;

        }

    }
}
