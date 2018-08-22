using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotateMatrix.BaseOperations.Abstract;
using RotateMatrix.ConsoleApp;

namespace RotateMatrix.Tests.Console
{
    [TestClass]
    public class WorkWithMatrixTest
    {
        [TestMethod]
        public void StartOperationTest()
        {
            var moMock = new Mock<IMatrixOperations>();
            moMock.Setup(mo => mo.Generate()).Returns(new int[,] { {1,2 },{1,4 } });
            moMock.Setup(mo => mo.Rotate(It.IsAny<int[,]>(), BaseOperations.RotateDirection.Right));

            var operation1 = new WorkWithMatrix(moMock.Object);
            var matrix = operation1.StartOperation();

            CollectionAssert.AllItemsAreNotNull(matrix);
        }
    }
}
