using System;
using System.Diagnostics.Contracts;
using Nif.Core.Extensions;
using NLog;

namespace Nif.Logging
{
    public class Logger : ILogger
    {
        private readonly NLog.Logger _logger;

        public Logger()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void Log(LogLevel logLevel, string message)
        {
            Contract.Requires<ArgumentNullException>(message.IsNotNullOrEmpty());

            switch (logLevel)
            {
                case LogLevel.Information:
                    {
                        _logger.Info(message);
                        break;
                    }
                
                case LogLevel.Warning:
                    {
                        _logger.Warn(message);
                        break;
                    }
                
                case LogLevel.Error:
                    {
                        _logger.Error(message);
                        break;
                    }
            
                default:
                    {
                        _logger.Debug(message);
                        break;
                    }
            }
        }
    }
}