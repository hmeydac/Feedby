namespace Ice.Infrastructure.Tests
{
    using System.Transactions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TransactionalUnitTest : InjectionUnitTest
    {
        private TransactionScope transaction;

        [TestInitialize]
        public void StartScope()
        {
            this.transaction = new TransactionScope();
        }

        [TestCleanup]
        public void CleanupScope()
        {
            this.transaction.Dispose();
        }
    }
}
