using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewCardsFramework.StaticBlindContexts;

namespace CardsFramework.Tests
{
    [TestClass]
    public class StaticBlindLevelTests
    {
        [TestMethod]
        public void CreateDatabaseConnection()
        {
            var dbLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var context = new LiteContext();
            Assert.IsNotNull(context);
        }
    }
}
