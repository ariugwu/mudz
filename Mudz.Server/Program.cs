using System.Collections.Generic;
using System.Net;
using easyTcp.Common.Model;
using easyTcp.Common.Model.Server;
using Mudz.Server.Domain.EasyTcp;

namespace Mudz.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var wat = new AsyncListener(new ConsoleProcessStrategy()) { Connections = new List<StateObject>() };
            wat.StartListening(IPAddress.Parse("127.0.0.1"), 4000);
        }
    }
}
