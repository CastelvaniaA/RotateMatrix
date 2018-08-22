using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotateMatrix.BaseOperations;
using RotateMatrix.BaseOperations.Abstract;

namespace RotateMatrix.Tests.Matrix
{
    [TestClass]
    public class RotationTest
    {
        private IRotation _rotation;

        public RotationTest()
        {
            this._rotation = new Rotation();
        }

        [TestMethod]
        public void RightRotation()
        {
            int[,] matrix44 =
            {
                    { 1, 2, 3, 4 },
                    { 5, 6, 7, 8 },
                    { 9, 10, 11, 12 },
                    { 13, 14, 15, 16 }
            };
            int[,] rotatedMatrix =
            {
                    { 13, 9, 5, 1 },
                    { 14, 10, 6, 2 },
                    { 15, 11, 7, 3 },
                    { 16, 12, 8, 4 }
            };

            _rotation.Rotate90Right(matrix44);

            CollectionAssert.AreEqual(rotatedMatrix, matrix44);
        }

        [TestMethod]
        public void LeftRotation()
        {
            int[,] matrix44 =
            {
                    { 1, 2, 3, 4 },
                    { 5, 6, 7, 8 },
                    { 9, 10, 11, 12 },
                    { 13, 14, 15, 16 }
            };
            int[,] rotatedMatrix =
            {
                    { 13, 9, 5, 1 },
                    { 14, 10, 6, 2 },
                    { 15, 11, 7, 3 },
                    { 16, 12, 8, 4 }
            };

            _rotation.Rotate90Left(matrix44);
            _rotation.Rotate90Left(matrix44);
            _rotation.Rotate90Left(matrix44);

            CollectionAssert.AreEqual(rotatedMatrix, matrix44);
        }
    }
}
