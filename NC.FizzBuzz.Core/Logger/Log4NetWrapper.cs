using System;
using log4net;
using NC.FizzBuzz.Core.Interfaces;

namespace NC.FizzBuzz.Core.Logger
{
    public class Log4NetWrapper : IAppLogger
    {
        private readonly ILog _logger;

        public Log4NetWrapper()
        {
            
        }
        private Log4NetWrapper(ILog log4NetLogger)
        {
            _logger = log4NetLogger;
        }

        public IAppLogger GetLogger(string name)
        {
            return new Log4NetWrapper(LogManager.GetLogger(name));
        }

        public void Info(string message)
        {
            _logger?.Info(message);
        }

        public void Error(string message)
        {
            _logger?.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            _logger?.Error(message, exception);
        }
    }
}
