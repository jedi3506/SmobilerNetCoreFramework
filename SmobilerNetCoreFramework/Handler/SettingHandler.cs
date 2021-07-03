using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Smobiler.Core;
using SmobilerNetCoreFramework.Log;

namespace SmobilerNetCoreFramework.Handler
{
    public class SettingHandler
    {
        private static string _HomeDictory = string.Empty;
        public static string GetHomePath(Smobiler.Core.MobileServer server)
        {
            if (string.IsNullOrEmpty(_HomeDictory))
            {
                _HomeDictory = server.Setting.ConfigPath;
            }
            return _HomeDictory;
        }
        public static List<(int serialNo, string propertyName, string value)> GetPropertys(Smobiler.Core.MobileServer server)
        {
            List<(int, string, string)> list = new List<(int, string, string)>();
            Setting setting = server.Setting;
            Type type = setting.GetType();
            PropertyInfo[] property = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            int tag = 1;
            foreach (var item in property)
            {
                object value = item.GetValue(setting);
                if (value.GetType().IsValueType || value is string)
                {
                    list.Add((tag, item.Name, value.ToString()));
                    tag++;
                }
            }
            return list;
        }

        public static void ShowSmobilerServerInfo(Smobiler.Core.MobileServer server)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Log.Log.Info("下面是启动服务的配置信息：");
            List<(int serialNo, string propertyName, string value)> list = GetPropertys(server);
            foreach (var item in list)
            {
                SmobilerNetCoreFramework.Log.Log.Info($"{item.serialNo}\t{item.propertyName}:{item.value}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Log.Log.Info("****** 您可以修改启动目录的Setting.config文件的相应内容来使配置发生改变！");
        }

        public static void Save(string key, string value)
        {

        }
    }
}
