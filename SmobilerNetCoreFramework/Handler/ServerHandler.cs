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
        public static void Start(string[] args)
        {
            if (!CommandParser(args))
            {
                throw new Exception("命令参数不正确，程序退出!");
            }
            Console.WriteLine("正在启动Smobiler服务....");
            InitConfig();
            ServerBind();
            _Server.StartServer();
            MobileGlobal.OnServerStart(_Server);
            Console.WriteLine("已成功启动Smobiler服务！");
            DetailShow();
        }

        private static bool CommandParser(string[] args)
        {
            (bool tag, int httpServerPort, int tcpServerPort) result = CommandHandler.ArgsParser(args);
            if (!result.tag)
            {
                return false;
            }

            HttpServerPort = result.httpServerPort;
            TcpServerPort = result.tcpServerPort;
            return true;
        }

        private static void DetailShow()
        {
        }

        private static void InitConfig()
        {
            Console.WriteLine("正在初始化smobiler服务配置文件....");


            Console.WriteLine("正在初始化smobiler服务配置文件....结束！");
        }
        private static void ServerBind()
        {
            Console.WriteLine("正在绑定smobiler服务配置文件....");
            Assembly assembly = Assembly.LoadFile(@"F:\FlaneSaas\smobilernetCoreframework\SmobilerNetCoreFramework\bin\Debug\net5.0\SmobilerNetCoreFramework.Test.exe");
            Type type = assembly.GetType("SmobilerNetCoreFramework.Test.SmobilerForm1");
            _Server.StartUpForm = type;
            //绑定事件
            _Server.SessionStart += MobileGlobal.OnSessionStart;
            _Server.SessionStop += MobileGlobal.OnSessionStop;
            _Server.SessionConnect += MobileGlobal.OnSessionConnect;
            _Server.ClientPushOpened += MobileGlobal.OnPushCallBack;
            Console.WriteLine("正在绑定smobiler服务配置文件....结束！");
        }
    }
}
