﻿using NLog;

namespace BookTask.Logs
{
    /// <summary>
    /// Logging.
    /// </summary>
    class Logger : ILogger
    {
        private static readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public void Trace(string message) => logger.Trace(message);

        public void Debug(string message) => logger.Debug(message);

        public void Info(string message) => logger.Info(message);

        public void Warn(string message) => logger.Warn(message);

        public void Error(string message) => logger.Error(message);

        public void Fatal(string message) => logger.Fatal(message);
    }
}
