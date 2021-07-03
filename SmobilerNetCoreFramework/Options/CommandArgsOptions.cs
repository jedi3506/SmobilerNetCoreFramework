using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace SmobilerNetCoreFramework.Options
{
    public class CommandArgsOptions
    {
        [Option('p', "http-server-port", HelpText = "http server port", Required = false)]
        public int HttpPort { get; set; }
        [Option('t', "", HelpText = "tcp server port", Required = false)]
        public int TcpPort { get; set; }
        [Option('a', "assembly", HelpText = "要在.netcore下运行的smobiler的APP程序", Required = true)]
        public string AssemblyName { get; set; }
        [Option('s', "startform", HelpText = "启动MobilerForm的全限定类名，包括命名空间", Required = true)]
        public string StartupFormName { get; set; }

    }
}
