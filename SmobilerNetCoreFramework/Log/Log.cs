using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;

namespace SmobilerNetCoreFramework.Log
{
    public static class Log
    {
        private static Log4jHelper _Loger = new Log4jHelper();
        public static void Debug(object logContent)
        {
            _Loger.Debug(logContent);
        }

        public static void Error(object logContent)
        {
            _Loger.Error(logContent);
        }

        public static void Fatal(object logContent)
        {
            _Loger.Fatal(logContent);
        }

        public static void Info(object logContent)
        {
            _Loger.Info(logContent);
        }

        public static void Trace(object logContent)
        {
            _Loger.Info(logContent);
        }

        public static void Warn(object logContent)
        {
            _Loger.Warn(logContent);
        }
    }
}
