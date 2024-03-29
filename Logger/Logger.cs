﻿using log4net;
using log4net.Config;
using System;
using System.IO;

namespace SPRA_SchJob.Log
{
    public class Logger
    {
        private static readonly ILog logger;
        static Logger()
        {
            if (logger == null)
            {
                var repository = LogManager.CreateRepository("NETCoreRepository");

                XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));

                logger = LogManager.GetLogger(repository.Name, "InfoLogger");
            }
        }

        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Info(string message, Exception exception = null)
        {
            if (exception == null)
                logger.Info(message);
            else
                logger.Info(message, exception);
        }

        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Warn(string message, Exception exception = null)
        {
            if (exception == null)
                logger.Warn(message);
            else
                logger.Warn(message, exception);
        }

        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(string message, Exception exception = null)
        {
            if (exception == null)
                logger.Error(message);
            else
                logger.Error(message, exception);
        }
    }
}
