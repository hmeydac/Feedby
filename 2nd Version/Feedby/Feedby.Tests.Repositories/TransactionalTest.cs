namespace Feedby.Tests.Repositories
{
    using System.Transactions;

    using Feedby.Infrastructure.DataContext;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TransactionalTest
    {
        public FeedbyDataContext Context { get; set; }

        public TransactionScope Transaction { get; set; }

        [TestInitialize]
        public void Startup()
        {
            this.Transaction = new TransactionScope();
            this.Context = new FeedbyDataContext();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (this.Transaction != null)
            {
                this.Transaction.Dispose();
            }
        }
    }
}
