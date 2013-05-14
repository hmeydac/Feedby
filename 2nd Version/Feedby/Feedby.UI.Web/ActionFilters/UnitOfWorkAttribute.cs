namespace Feedby.UI.Web.ActionFilters
{
    using System;
    using System.Web.Mvc;

    using Feedby.Infrastructure.DataContext;

    using Ninject;

    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        public IKernel Container { get; set; }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            try
            {
                this.Container.Get<FeedbyDataContext>().SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO: Handle Exception
            }
        }
    }
}