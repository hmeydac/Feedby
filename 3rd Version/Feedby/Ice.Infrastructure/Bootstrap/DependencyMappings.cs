namespace Ice.Infrastructure.Bootstrap
{
    using System.Data.Entity;

    using Ice.Infrastructure.DataContext;

    using Ninject;
    using Ninject.Web.Common;

    public class DependencyMappings
    {
        public static IKernel GetKernel()
        {
            return new StandardKernel();
        }

        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<SocialModelContext>().InRequestScope();
        }
    }
}
