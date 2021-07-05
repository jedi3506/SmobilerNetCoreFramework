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
        private static Type _StartType = null;
        public static void Start(string[] args)
        {
            if (!CommandParser(args))
            {
                throw new Exception("命令参数不正确，程序退出!");
            }
            Console.WriteLine("starting Smobiler service....");
            ServerBind();
            _Server.StartServer();
            OnServerStart();

            Console.WriteLine("already started Smobiler service!");
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
            Console.WriteLine("Binding Smobiler Service Config files....");
            string exeName = string.Empty;
            string startFormName = string.Empty;
            if (!string.IsNullOrEmpty(assemblyName))
            {
                exeName = assemblyName;
                startFormName = startupForm;
            }
            Assembly assembly = Assembly.LoadFile(exeName);
            _StartType = assembly.GetType(startFormName);
            _Server.StartUpForm = _StartType;
            if (HttpServerPort != 0)
            {
                _Server.Setting.HttpServerPort = HttpServerPort;
                _Server.Setting.TcpServerPort = TcpServerPort;
            }
            //绑定事件
            _Server.SessionStart += _Server_SessionStart;
            _Server.SessionStop += _Server_SessionStop;
            _Server.SessionConnect += _Server_SessionConnect; ;
            _Server.ClientPushOpened += _Server_ClientPushOpened;

            Console.WriteLine("inding Smobiler Service Config files....Finished!");
        }

        private static void _Server_ClientPushOpened(object sender, ClientPushOpenedEventArgs e)
        {
            _MehtodInvoke(_StartType, () => "OnPushCallBack", sender, e);
        }

        public static void OnServerStart()
        {
            MethodInfo method = _StartType.GetMethod("OnServerStart", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            method.Invoke(_Server, new object[] { });
        }

        private static void _MehtodInvoke(Type type,Func<string> func,object sender,object e)
        {
            MethodInfo method = _StartType.GetMethod(func.Invoke(), BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            method.Invoke(_Server, new object[] { sender, e });
        }

        private static void _Server_SessionConnect(object sender, SmobilerSessionEventArgs e)
        {
            _MehtodInvoke(_StartType, () => "OnSessionConnect", sender, e);
        }

        private static void _Server_SessionStop(object sender, SmobilerSessionEventArgs e)
        {
            _MehtodInvoke(_StartType, () => "OnSessionStop", sender, e);
        }

        private static void _Server_SessionStart(object sender, SmobilerSessionEventArgs e)
        {
            _MehtodInvoke(_StartType, () => "OnSessionStart", sender, e);
        }
    }
}
