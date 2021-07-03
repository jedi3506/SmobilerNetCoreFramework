using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmobilerNetCoreFramework.Handler;
using SmobilerNetCoreFramework.Log;

namespace SmobilerNetCoreFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //启动smobiler服务
            ServerHandler.Start(args);
            Task.Run(() =>
            {
                SignalHander.WaitOne();
                Log.Log.Info("****** 在布署的时候您可以将上面的链接替换成真正的IP来进行访问！");
                SettingHandler.ShowSmobilerServerInfo(ServerHandler._Server);
            });
            IHost host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    }
}
