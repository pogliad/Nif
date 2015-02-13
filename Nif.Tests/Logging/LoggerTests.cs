using NUnit.Framework;
using Nif.Logging;

namespace Nif.Tests.Logging
{
    [TestFixture]
    public class LoggerTests
    {
        [Test]
        public void EnsureThat_Logger_IsInstantiated()
        {
            // Arrange

            // Act
            var logger = new Logger();

            // Assert
            Assert.NotNull(logger);
        }
    }
}