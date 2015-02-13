using Nif.Logging;
using Nif.Utilities;
using NSubstitute;
using NUnit.Framework;

namespace Nif.Tests.Logging
{
    [TestFixture]
    public class LoggerExtensionsTests
    {
        private ILogger _logger;
        private string _message;

        [SetUp]
        public void SetUp()
        {
            _logger = Substitute.For<ILogger>();
            _message = StringGeneratorUtility.Generate<DefaultCharsProvider>(1);
        }

        [TearDown]
        public void TearDown()
        {
            _logger = null;
            _message = null;
        }

        [Test]
        public void EnsureThat_LogDebug_CallsLogOneTime()
        {
            // Arrange

            // Act
            _logger.LogDebug(_message);

            // Assert
            _logger.Received(1).Log(LogLevel.Debug, Arg.Any<string>());
        }

        [Test]
        public void EnsureThat_LogInformation_CallsLogOneTime()
        {
            // Arrange

            // Act
            _logger.LogInformation(_message);

            // Assert
            _logger.Received(1).Log(LogLevel.Information, Arg.Any<string>());
        }

        [Test]
        public void EnsureThat_LogWarning_CallsLogOneTime()
        {
            // Arrange

            // Act
            _logger.LogWarning(_message);

            // Assert
            _logger.Received(1).Log(LogLevel.Warning, Arg.Any<string>());
        }

        [Test]
        public void EnsureThat_LogError_CallsLogOneTime()
        {
            // Arrange

            // Act
            _logger.LogError(_message);

            // Assert
            _logger.Received(1).Log(LogLevel.Error, Arg.Any<string>());
        }
    }
}