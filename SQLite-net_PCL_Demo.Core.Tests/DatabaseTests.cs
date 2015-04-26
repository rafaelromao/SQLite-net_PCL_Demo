using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SQLite_net_PCL_Demo.Core.Repositories;

namespace SQLite_net_PCL_Demo.Core.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void TestDatabaseInitialization()
        {
            Assert.IsFalse(Repository.DatabaseExists());

            var repository = new Repository();
            repository.Initialize();

            Assert.IsTrue(Repository.DatabaseExists());
        }
    }
}
