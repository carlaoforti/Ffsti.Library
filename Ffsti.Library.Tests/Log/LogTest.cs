using Ffsti.Library.NLog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog.Targets;

namespace Ffsti.Library.Tests.Log
{
    [TestClass]
    public class LogTest
    {
        [TestMethod]
        public void Should_Create_Console_Logger()
        {
            Assert.IsTrue(false);
            var helper = new LogHelper();
            var logger = helper.CreateConfiguration<FileTarget>("Teste");
            logger.Debug("Teste");
            logger.Error("Error");
        }
    }
}
