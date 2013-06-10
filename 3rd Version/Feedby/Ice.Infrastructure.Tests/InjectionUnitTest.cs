namespace Ice.Infrastructure.Tests
{
    using Ice.Infrastructure.Bootstrap;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Ninject;

    [TestClass]
    public class InjectionUnitTest
    {
        private IKernel dependencyKernel;

        protected IKernel Kernel
        {
            get
            {
                return this.dependencyKernel;
            }
        }

        [TestInitialize]
        public void Startup()
        {
            this.dependencyKernel = DependencyMappings.GetKernel();
            DependencyMappings.RegisterServices(this.Kernel);
        }
    }
}