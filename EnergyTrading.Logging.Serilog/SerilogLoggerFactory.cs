﻿using System;
using System.Runtime.InteropServices;
using Serilog;

namespace EnergyTrading.Logging.Serilog
{
    public class SerilogLoggerFactory : ILoggerFactory
    {
        private readonly global::Serilog.ILogger _serilogLogger;
        public SerilogLoggerFactory(Func<LoggerConfiguration, LoggerConfiguration> configureFunc)
        {
            var configuration = new LoggerConfiguration().MinimumLevel.Debug();
            _serilogLogger = configureFunc != null ? configureFunc(configuration).CreateLogger() : configuration.WriteTo.Console().CreateLogger();
        }

        public ILogger GetLogger(string name)
        {
            return new SerilogLogger(_serilogLogger);
        }

        public ILogger GetLogger<T>()
        {
            return new SerilogLogger(_serilogLogger);
        }

        public void Initialize()
        {
        }

        public void Shutdown()
        {
        }

        public ILogger GetLogger(Type type)
        {
            return new SerilogLogger(_serilogLogger);
        }
    }
}