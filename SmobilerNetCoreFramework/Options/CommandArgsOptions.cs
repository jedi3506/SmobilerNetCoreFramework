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
        [Option('t',"",HelpText="tcp server port",Required = false)]
        public int TcpPort { get; set; }

}
}
