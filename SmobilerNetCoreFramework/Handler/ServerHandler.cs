using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Smobiler;
using Smobiler.Core;
using System.Reflection;
using System.Linq;

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
        private static Assembly _Assembly = null;
        private static Type _MobileGlobalType = null;
        public static void Start(string[] args)
        {
            if (!CommandParser(args))
            {
                throw new Exception("命令参数不正确，程序退出!");
            }

            Log.Log.Info($"smobiler configpath:{_Server.Setting.ConfigPath}");
            Log.Log.Info($"current dir:{Environment.CurrentDirectory}");
            Log.Log.Info("starting Smobiler service....");
            ServerBind();
            _Server.StartServer();
            OnServerStart();
            Log.Log.Info("Already started Smobiler service!");
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
            Log.Log.Info("Binding Smobiler Service Config files....");
            string exeName = string.Empty;
            string startFormName = string.Empty;
            if (!string.IsNullOrEmpty(assemblyName))
            {
                exeName = assemblyName;
                startFormName = startupForm;
            }
            _Assembly = Assembly.LoadFile(exeName);
            _StartType = _Assembly.GetType(startFormName, true, true);
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

            Log.Log.Info("Binding Smobiler Service Config files....Finished!");
        }

        private static void _Server_ClientPushOpened(object sender, ClientPushOpenedEventArgs e)
        {
            _MehtodInvoke(() => "OnPushCallBack", sender, e);
        }

        public static void OnServerStart()
        {
            if (_MobileGlobalType == null)
            {
                _MobileGlobalType = GetMobileGlobalType();
            }
            if (_MobileGlobalType == null)
            {
                return;
            }

            _MobileGlobalType.InvokeMember("OnServerStart",BindingFlags.InvokeMethod  | BindingFlags.Static | BindingFlags.Public,
                null, null, new object[] {_Server});
        }

        private static void _MehtodInvoke(Func<string> func, object sender, object e)
        {
            if (_MobileGlobalType == null)
            {
                _MobileGlobalType = GetMobileGlobalType();
            }
            if (_MobileGlobalType == null)
            {
                return;
            }
            _MobileGlobalType.InvokeMember(func.Invoke(),BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public,
                null,null,new object[] { sender,e});
        }

        private static Type GetMobileGlobalType()
        {
            return _Assembly.GetType("MobileGlobal", false, true);
        }

        private static void _Server_SessionConnect(object sender, SmobilerSessionEventArgs e)
        {
            _MehtodInvoke(() => "OnSessionConnect", sender, e);
        }

        private static void _Server_SessionStop(object sender, SmobilerSessionEventArgs e)
        {
            _MehtodInvoke(() => "OnSessionStop", sender, e);
        }

        private static void _Server_SessionStart(object sender, SmobilerSessionEventArgs e)
        {
            _MehtodInvoke(() => "OnSessionStart", sender, e);
        }
    }
}
