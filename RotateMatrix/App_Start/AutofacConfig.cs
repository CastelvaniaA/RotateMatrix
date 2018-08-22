using Autofac;
using Autofac.Integration.Mvc;
using RotateMatrix.BaseOperations.Abstract;
using RotateMatrix.BaseOperations.Concrete;
using System.Web.Mvc;

namespace RotateMatrix
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterType<MatrixOperations>().As<IMatrixOperations>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}