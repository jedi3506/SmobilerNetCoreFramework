using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


[assembly: log4net.Config.XmlConfigurator(ConfigFile = @"Config/log4net.config", Watch = true)]
namespace SmobilerNetCoreFramework.Log
{
    /// <summary>
    /// log4j帮助类.
    /// </summary>
    public class Log4jHelper
    {
        private static log4net.ILog _Loger = null;
        public Log4jHelper()
        {
            if (_Loger == null)
            {
                _Loger = log4net.LogManager.GetLogger("Log");
            }
        }
        public void Debug(object logContent)
        {
            _Loger.Debug(logContent);
        }

        public void Error(object logContent)
        {
            _Loger.Error(logContent);
        }

        public void Fatal(object logContent)
        {
            _Loger.Fatal(logContent);
        }

        public void Info(object logContent)
        {
            _Loger.Info(logContent);
        }

        public void Trace(object logContent)
        {
            _Loger.Info(logContent);
        }

        public void Warn(object logContent)
        {
            _Loger.Warn(logContent);
        }
    }
}
