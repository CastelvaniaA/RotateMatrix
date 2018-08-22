using Autofac;
using RotateMatrix.BaseOperations;
using RotateMatrix.BaseOperations.Abstract;
using RotateMatrix.BaseOperations.Concrete;

namespace RotateMatrix
{
    public class AutofacConfig
    {
        public IContainer Container { private set;  get; }

        public AutofacConfig()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Rotation>().As<IRotation>();
            builder.RegisterType<MatrixOperations>().UsingConstructor(typeof(IRotation)).As<IMatrixOperations>();
            this.Container = builder.Build();
        }
    }
}