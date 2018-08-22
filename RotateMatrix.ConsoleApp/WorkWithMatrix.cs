using RotateMatrix.BaseOperations.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateMatrix.ConsoleApp
{
    public class WorkWithMatrix
    {
        private IMatrixOperations _matrixOp;

        public WorkWithMatrix(IMatrixOperations matrixOperations)
        {
            this._matrixOp = matrixOperations;
        }

        public int[,] StartOperation()
        {
            int[,] matrix = this._matrixOp.Generate();

            Console.WriteLine("\n--- Generated matrix \n");
            Display(matrix);

            this._matrixOp.Rotate(matrix, BaseOperations.RotateDirection.Right);
            Console.WriteLine("\n--- Right rotated matrix \n");
            Display(matrix);

            return matrix;
        }

        public void SaveToFile(int[,] matrix)
        {
            var bytes = this._matrixOp.Export(matrix);
            File.WriteAllBytes("RightRotatedMatrix.csv", bytes);
            Console.WriteLine("\n--- Matrix saved. \n");
        }

        private void Display(int[,] matrix)
        {
            var n = Math.Sqrt(matrix.Length);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
