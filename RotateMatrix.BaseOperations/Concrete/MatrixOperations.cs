using RotateMatrix.BaseOperations.Abstract;
using System;
using System.Text;
using System.IO;

namespace RotateMatrix.BaseOperations.Concrete
{
    public class MatrixOperations : IMatrixOperations
    {
        private IRotation _rotation;
        public MatrixOperations(IRotation rotation)
        {
            this._rotation = rotation;
        }

        public byte[] Export(int[,] matrix)
        {
            byte[] result;
            var n = Math.Sqrt(matrix.Length);
            using (var memStream = new MemoryStream())
            {
                using (var outfile = new StreamWriter(memStream, Encoding.UTF8))
                {
                    for (int i = 0; i < n; i++)
                    {
                        string content = string.Empty;
                        for (int j = 0; j < n; j++)
                        {
                            if (j == n - 1)
                            {
                                content += matrix[i, j].ToString();
                            }
                            else
                            {
                                content += matrix[i, j].ToString() + ",";
                            }
                        }
                        outfile.WriteLine(content);
                    }
                    var b = outfile.ToString();
                    outfile.Flush();
                    result = new byte[memStream.Length];

                    memStream.Position = 0;
                    memStream.Read(result, 0, (int)memStream.Length);
                    memStream.Close();
                }
            }

            return result;
        }

        public int[,] Generate()
        {
            var random = new Random();
            var n = random.Next(2, 20);  // Set maximum dimension

            var matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = random.Next(-100,100); // Set numbers Interval
                }
            }

            return matrix;
        }

        public void Import(int[,] matrix, Stream fileStream)
        {
            using (StreamReader sr = new StreamReader(fileStream))
            {
                int Row = 0;
                int n = 0;
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    if (Row == 0)
                    {
                        n = line.Length;
                        matrix = new int[n, n];
                    }

                    for (int i = 0; i <= line.Length - 1; i++)
                    {
                        try
                        {
                            var a = int.Parse(line[i]);
                            matrix[Row, i] = a;
                        }
                        catch (FormatException)
                        {
                            throw new ArgumentException("Ошибка входных данных");
                        }
                        catch(OverflowException)
                        {
                            throw new ArgumentException("Ошибка входных данных");
                        }      
                    }
                    Row++;
                }
                if (Row != n)
                {
                    throw new ArgumentException("Исходная матрица не квадратная!");
                }
            }
        }

        public void Rotate(int[,] matrix, RotateDirection rotateDirection = RotateDirection.Right)
        {
            switch (rotateDirection)
            {
                case RotateDirection.Right:
                    this._rotation.Rotate90Right(matrix);
                    break;
                case RotateDirection.Left:
                    this._rotation.Rotate90Left(matrix);
                    break;
            }
        }
    }
}
