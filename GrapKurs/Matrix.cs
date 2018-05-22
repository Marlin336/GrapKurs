using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapKurs
{
    class Matrix
    {
        public double[,] Elems { get; }
        public int Columns { get; }
        public int Rows { get; }
        public Matrix(int Rows, int Columns)
        {
            Elems = new double[Rows, Columns];
            this.Columns = Columns;
            this.Rows = Rows;
        }
        public static Matrix operator * (Matrix m1, Matrix m2)
        {
            if(m1.Columns != m2.Rows)
            {
                throw new Exception("Умножать матрицы только когда количество столбцов m1 равно количеству строк m2.");
            }
            Matrix res = new Matrix(m1.Rows, m2.Columns);
            for (int k = 0; k < res.Rows; k++)
                for (int i = 0; i < res.Columns; i++)
                    for (int j = 0; j < res.Rows; j++)
                        res.Elems[k, i] += m1.Elems[k, j] * m2.Elems[j, i];
            return res;
        }
        public static Matrix operator * (Matrix matrix, int mul)
        {
            Matrix res = new Matrix(matrix.Rows, matrix.Columns);
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                    res.Elems[i, j] = matrix.Elems[i, j] * mul;
            return res;
        }
    }
}
