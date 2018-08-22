using Autofac;
using RotateMatrix.BaseOperations.Abstract;
using System;

namespace RotateMatrix.ConsoleApp
{
    public class Program
    {
        private static IContainer _DIContainer;

        static void Main(string[] args)
        {
            var DIConfig = new AutofacConfig();
            _DIContainer = DIConfig.Container;

            using (var scope = _DIContainer.BeginLifetimeScope())
            {
                var operation1 = new WorkWithMatrix(scope.Resolve<IMatrixOperations>());
                var matrix = operation1.StartOperation();
                operation1.SaveToFile(matrix);

                Console.ReadKey();
            }
        }
    }
}
