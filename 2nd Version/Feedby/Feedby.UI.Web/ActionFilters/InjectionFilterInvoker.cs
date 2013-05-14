namespace Feedby.UI.Web.ActionFilters
{
    using System.Linq;
    using System.Web.Mvc;

    using Ninject;

    using WebGrease.Css.Extensions;

    public class InjectionFilterInvoker : ControllerActionInvoker
    {
        private readonly IKernel container;

        public InjectionFilterInvoker(IKernel container)
        {
            this.container = container;
        }

        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filtersInfo = base.GetFilters(controllerContext, actionDescriptor);

            filtersInfo.ActionFilters
                .Where(af => af is UnitOfWorkAttribute)
                .ForEach(af => ((UnitOfWorkAttribute)af).Container = this.container);

            return filtersInfo;
        }
    }
}