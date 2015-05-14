using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using NewRelic.Platform.Sdk.Configuration;
using log4net;

namespace NewRelic.Platform.Sdk.Utils
{
    public sealed class Logger
    {
        private  readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
 

        public static LogLevel LogLevel { get; private set; }
 

        public void Debug(string format, params object[] items)
        {
            this._logger.Debug(format);
        }

        public void Info(string format, params object[] items)
        {
            this._logger.Info(format);
        }

        public void Warn(string format, params object[] items)
        {
            this._logger.Warn(format);
        }

        public void Error(string format, params object[] items)
        {
            this._logger.Error(format);
        }

        public void Fatal(string format, params object[] items)
        {
            this._logger.Fatal(format);
        }

        public static Logger GetLogger(string className)
        {
            return new Logger();
        }
 
    }
}
