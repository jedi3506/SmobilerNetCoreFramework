using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using SmobilerNetCoreFramework.Options;

namespace SmobilerNetCoreFramework.Handler
{
    public class CommandHandler
    {
        public static (bool tag, int httpServerPort, int tcpServerPort) ArgsParser(string[] args)
        {
            int httpServerPort = 0;
            int tcpServerPort = 0;
            ParserResult<CommandArgsOptions> result = Parser.Default.ParseArguments<CommandArgsOptions>(args).WithParsed((o) =>
            {
                httpServerPort = o.HttpPort;
                tcpServerPort = o.TcpPort;
            });

            bool tag = result.Tag.Equals(ParserResultType.Parsed) ? true : false;
            return (tag,httpServerPort,tcpServerPort);
        }
    }
}
