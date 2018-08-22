using RotateMatrix.BaseOperations.Abstract;
using System;

namespace RotateMatrix.BaseOperations
{
    public class Rotation : IRotation
    {
        public void Rotate90Left(int[,] inputMatrix)
        {
            var n = (int)Math.Sqrt(inputMatrix.Length);
            var repeatCount = n % 2 == 0 ? n / 2 : n - 1 / 2;

            int i = 0;
            int j = 0;

            // Number of levels
            for (int nestedLevel = 0; nestedLevel <= repeatCount - 1; nestedLevel++)
            {
                // repeat count
                for (int t = 0; t < n - nestedLevel * 2 - 1; t++)
                {
                    j = nestedLevel;
                    var le0 = inputMatrix[n - nestedLevel - 1, nestedLevel];
                    for (int r = n - nestedLevel - 1; r > nestedLevel; r--)
                    {
                        inputMatrix[r, j] = inputMatrix[r - 1, j];
                    }


                    i = n - nestedLevel - 1;
                    var le1 = inputMatrix[i, n - nestedLevel - 1];
                    for (int c = n - nestedLevel - 1; c > nestedLevel + 1; c--)
                    {
                        inputMatrix[i, c] = inputMatrix[i, c - 1];
                    }
                    inputMatrix[i, nestedLevel + 1] = le0;


                    j = n - nestedLevel - 1;
                    le0 = inputMatrix[nestedLevel, j];
                    for (int r = nestedLevel; r < n - nestedLevel - 1; r++)
                    {
                        inputMatrix[r, j] = inputMatrix[r + 1, j];
                    }
                    inputMatrix[n - nestedLevel - 1 - 1, j] = le1;


                    i = nestedLevel;
                    le1 = inputMatrix[nestedLevel, nestedLevel];
                    for (int c = nestedLevel; c < n - nestedLevel - 1; c++)
                    {
                        inputMatrix[i, c] = inputMatrix[i, c + 1];
                    }
                    inputMatrix[i, n - nestedLevel - 1 - 1] = le0;
                }
            }
        }

        public void Rotate90Right(int[,] inputMatrix)
        {
            var n = (int)Math.Sqrt(inputMatrix.Length);
            var repeatCount = n % 2 == 0 ? n / 2 : n - 1 / 2;

            int i = 0;
            int j = 0;

            // Number of levels
            for (int nestedLevel = 0; nestedLevel <= repeatCount - 1; nestedLevel++)
            {
                // repeat count
                for (int t = 0; t < n - nestedLevel * 2 - 1; t++)
                {

                    i = nestedLevel;
                    var le0 = inputMatrix[i, n - nestedLevel - 1];
                    for (int c = n - nestedLevel - 1; c > nestedLevel; c--)
                    {
                        inputMatrix[i, c] = inputMatrix[i, c - 1];
                    }


                    j = n - nestedLevel - 1;
                    var le1 = inputMatrix[n - nestedLevel - 1, j];
                    for (int r = n - nestedLevel - 1; r > nestedLevel + 1; r--)
                    {
                        inputMatrix[r, j] = inputMatrix[r - 1, j];
                    }
                    inputMatrix[nestedLevel + 1, j] = le0;


                    i = n - nestedLevel - 1;
                    le0 = inputMatrix[i, nestedLevel];
                    for (int c = nestedLevel; c < n - nestedLevel - 1; c++)
                    {
                        inputMatrix[i, c] = inputMatrix[i, c + 1];
                    }
                    inputMatrix[i, n - nestedLevel - 1 - 1] = le1;



                    j = nestedLevel;
                    for (int r = nestedLevel; r < n - nestedLevel - 1; r++)
                    {
                        inputMatrix[r, j] = inputMatrix[r + 1, j];
                    }
                    inputMatrix[n - nestedLevel - 1 - 1, j] = le0;

                }
            }
        }
    }
}
