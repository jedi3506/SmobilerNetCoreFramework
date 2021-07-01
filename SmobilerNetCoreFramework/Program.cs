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
            SmobilerNetCoreFramework.Log.Log.Info("just test.");
            //Æô¶¯smobiler·þÎñ
            Task.Run(()=>ServerHandler.Start(args));
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
