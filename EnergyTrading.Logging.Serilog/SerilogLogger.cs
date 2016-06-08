using System;
using System.Net;

namespace EnergyTrading.Logging.Serilog
{
    public class SerilogLogger : ILogger
    {
        private readonly global::Serilog.ILogger logger;
        public SerilogLogger(global::Serilog.ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            this.logger = logger;
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void DebugFormat(string format, params object[] parameters)
        {
            logger.Debug(format.ToSerilogFormat(parameters), parameters);
        }

        public void Info(string message)
        {
            logger.Information(message);
        }

        public void InfoFormat(string format, params object[] parameters)
        {
            logger.Information(format.ToSerilogFormat(parameters), parameters);
        }

        public void Warn(string message)
        {
            logger.Warning(message);
        }

        public void WarnFormat(string format, params object[] parameters)
        {
            logger.Warning(format.ToSerilogFormat(parameters), parameters);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void ErrorFormat(string format, params object[] parameters)
        {
            logger.Error(format.ToSerilogFormat(parameters), parameters);
        }

        public void Fatal(string message)
        {
            logger.Fatal(message);
        }

        public void FatalFormat(string format, params object[] parameters)
        {
            logger.Fatal(format.ToSerilogFormat(parameters), parameters);
        }

        public bool IsDebugEnabled => true;

        public bool IsInfoEnabled => true;

        public bool IsWarnEnabled => true;

        public bool IsErrorEnabled => true;

        public bool IsFatalEnabled => true;

        public void Fatal(string message, Exception exception)
        {
            logger.Fatal(exception, message);
        }

        public void Error(string message, Exception exception)
        {
            logger.Error(exception, message);
        }

        public void Warn(string message, Exception exception)
        {
            logger.Warning(exception, message);
        }

        public void Info(string message, Exception exception)
        {
            logger.Information(exception, message);
        }

        public void Debug(string message, Exception exception)
        {
            logger.Debug(exception, message);
        }
    }
}