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
        private static Smobiler.Core.MobileServer _Server = new MobileServer();
        public static void Start(string[] args)
        {
            Console.WriteLine("正在启动Smobiler服务....");
            InitConfig();
            ServerBind();
            _Server.StartServer();
            Console.WriteLine("成功启动Smobiler服务！下面是启动明细信息：");
            DetailShow();
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
            Assembly assembly = Assembly.LoadFile(Environment.CurrentDirectory+ "/bin/Debug/net5.0/SmobilerNetCoreFramework.Test.exe");
            Type type = assembly.GetType("SmobilerNetCoreFramework.Test.SmobilerForm1");
            _Server.StartUpForm = type;
            //绑定事件
            _Server.SessionStart += MobileGlobal.OnSessionStart;
            _Server.SessionStop += MobileGlobal.OnSessionStop;
            _Server.SessionConnect += MobileGlobal.OnSessionConnect;
            _Server.ClientPushOpened += MobileGlobal.OnPushCallBack;
            MobileGlobal.OnServerStart(_Server);
            MobileGlobal.OnServerStop(_Server);
            Console.WriteLine("正在绑定smobiler服务配置文件....结束！");
        }
    }
}
