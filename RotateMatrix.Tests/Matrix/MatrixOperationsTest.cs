using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotateMatrix.BaseOperations;
using RotateMatrix.BaseOperations.Abstract;
using RotateMatrix.BaseOperations.Concrete;

namespace RotateMatrix.Tests
{
    [TestClass]
    public class TestMatrixOperations
    {
        private MatrixOperations _mo; 
        public TestMatrixOperations()
        {
            var rotationMock = new Mock<IRotation>();

            rotationMock.Setup(m => m.Rotate90Right(It.IsIn<int[,]>()));
            rotationMock.Setup(m => m.Rotate90Left(It.IsIn<int[,]>()));

            _mo = new MatrixOperations(rotationMock.Object);
        }

        [TestMethod]
        public void RightLeftRotation()
        {
            _mo.Rotate(It.IsAny<int[,]>());
        }

        [TestMethod]
        public void Generation()
        {
            var matrix = _mo.Generate();
            CollectionAssert.AllItemsAreNotNull(matrix);
        }

        [TestMethod]
        public void Exporting()
        {
            int[,] matrix = { { 1, 2 }, { 3, 5 } };
            var bytes = _mo.Export(matrix);

            CollectionAssert.AllItemsAreNotNull(bytes);
        }
    }
}
