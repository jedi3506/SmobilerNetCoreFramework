using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Smobiler;
using Smobiler.Core;
using System.Reflection;

namespace SmobilerNetCoreFramework.Handler
{
    /// <summary>
    /// smobiler服务处理器
    /// </summary>
    public class ServerHandler
    {
        public static Smobiler.Core.MobileServer _Server = new MobileServer();
        private static int HttpServerPort = 0;
        private static int TcpServerPort = 0;
        private static string assemblyName = string.Empty;
        private static string startupForm = string.Empty;
        public static void Start(string[] args)
        {
            if (!CommandParser(args))
            {
                throw new Exception("命令参数不正确，程序退出!");
            }
            Console.WriteLine("正在启动Smobiler服务....");
            ServerBind();
            _Server.StartServer();
            MobileGlobal.OnServerStart(_Server);
            Console.WriteLine("已成功启动Smobiler服务！");
        }

        private static bool CommandParser(string[] args)
        {
            (bool tag, int httpServerPort, int tcpServerPort, string assemblyName, string startupForm) result = CommandHandler.ArgsParser(args);
            if (!result.tag)
            {
                return false;
            }

            HttpServerPort = result.httpServerPort;
            TcpServerPort = result.tcpServerPort;
            assemblyName = result.assemblyName;
            startupForm = result.startupForm;
            return true;
        }
        private static void ServerBind()
        {
            Console.WriteLine("正在绑定smobiler服务配置文件....");
            string exeName = string.Empty;
            string startFormName = string.Empty;
            if (!string.IsNullOrEmpty(assemblyName))
            {
                exeName = assemblyName;
                startFormName = startupForm;
            }
            Assembly assembly = Assembly.LoadFile(exeName);
            _Server.StartUpForm = assembly.GetType(startFormName);
            if (HttpServerPort != 0)
            {
                _Server.Setting.HttpServerPort = HttpServerPort;
                _Server.Setting.TcpServerPort = TcpServerPort;
            }
            //绑定事件
            _Server.SessionStart += MobileGlobal.OnSessionStart;
            _Server.SessionStop += MobileGlobal.OnSessionStop;
            _Server.SessionConnect += MobileGlobal.OnSessionConnect;
            _Server.ClientPushOpened += MobileGlobal.OnPushCallBack;
            Console.WriteLine("正在绑定smobiler服务配置文件....结束！");
        }
    }
}
