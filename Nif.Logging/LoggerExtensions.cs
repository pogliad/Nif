using System;
using System.Diagnostics.Contracts;
using Nif.Extensions;

namespace Nif.Logging
{
    public static class LoggerExtensions
    {
        public static void LogDebug(this ILogger logger, string message)
        {
            Contract.Requires<ArgumentNullException>(logger.IsNotNull());
            Contract.Requires<ArgumentNullException>(message.IsNotNullOrEmpty());

            logger.Log(LogLevel.Debug, message);
        }

        public static void LogInformation(this ILogger logger, string message)
        {
            Contract.Requires<ArgumentNullException>(logger.IsNotNull());
            Contract.Requires<ArgumentNullException>(message.IsNotNullOrEmpty());


            logger.Log(LogLevel.Information, message);
        }

        public static void LogWarning(this ILogger logger, string message)
        {
            Contract.Requires<ArgumentNullException>(logger.IsNotNull());
            Contract.Requires<ArgumentNullException>(message.IsNotNullOrEmpty());

            logger.Log(LogLevel.Warning, message);
        }

        public static void LogError(this ILogger logger, string message)
        {
            Contract.Requires<ArgumentNullException>(logger.IsNotNull());
            Contract.Requires<ArgumentNullException>(message.IsNotNullOrEmpty());

            logger.Log(LogLevel.Error, message);
        }
    }
}