using System.Text;

namespace ConsoleApp1
{
    internal class Matrix
    {
        private int rows;
        private int columns;
        private int[,] matrix;

        public int Rows
        {
            get { return rows; }
        }

        public int Columns
        {
            get { return columns; }
        }

        public int this[int i, int j]
        {
            get { return matrix[i, j]; }
            private set { matrix[i, j] = value; }
        }

        public Matrix(int r, int c)
        {
            rows = r;
            columns = c;
            matrix = new int[rows, columns];
        }

        public void FillRandom()
        {
            var r = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    matrix[i, j] = r.Next(10);
            }
        }

        public Matrix Transpose(Matrix m)
        {
            var res = new Matrix(columns, rows);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    res[j, i] = m[i, j];
                }
            }
            return res;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    sb.Append($"{matrix[i, j],2}");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.rows > b.rows || a.columns > b.columns)
                throw new ArgumentException("Размерности матриц должны быть одинаковыми");
            var res = new Matrix(a.rows, a.columns);
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                    res[i, j] += a[i, j] + b[i, j];
            }
            return res;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.rows > b.rows || a.columns > b.columns)
                throw new ArgumentException("Размерности матриц должны быть одинаковыми");
            var res = new Matrix(a.rows, a.columns);
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                    res[i, j] += a[i, j] - b[i, j];
            }
            return res;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.columns > b.rows)
                throw new ArgumentException("Умножаются только матрицы размерностей m x n и n x k");
            var res = new Matrix(a.rows, b.columns);
            for (int i = 0; i < a.rows; i++)
                for (int j = 0; j < b.columns; j++)
                    for (int k = 0; k < b.rows; k++)
                        res[i, j] += a[i, k] * b[k, j];

            return res;
        }

        // Контрольная работа 06.12.2023
        // **********************************************************************************************
        // **********************************************************************************************

        public Matrix(string filename) 
        {
            using StreamReader streamReader = new StreamReader(filename);
            var size = streamReader.ReadLine().Split(' '); 
            rows = Convert.ToInt32(size[0]);
            columns = Convert.ToInt32(size[1]);
            matrix = new int[rows, columns];
            var m = streamReader.ReadToEnd().Split('\n');
            for (int i = 0; i < rows; i++)
            {
                var line = m[i].Split(' ');
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = Convert.ToInt32(line[j]);
                }
            }
        }

        public void Swap(int a, int b)
        {
            for (int i = 0; i < columns; i++)
            {
                (matrix[a, i], matrix[b, i]) = (matrix[b, i], matrix[a, i]);
            }
        }

        public void SwapMaxAndMin()
        {
            var max = int.MinValue;
            var min = int.MaxValue;
            var maxIndex = 0;
            var minIndex = 0;

            for (int i = 0; i < rows; i++) 
            {
                int sum = 0;
                for (int j = 0; j < columns; j++)
                    sum += matrix[i, j];
                if (sum > max)
                {
                    max = sum;
                    maxIndex = i;
                }
                if (sum < min)
                {
                    min = sum;
                    minIndex = i;
                }
            }
            Swap(maxIndex, minIndex);
        }
    }
}