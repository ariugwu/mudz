using System.Collections.Generic;
using System.Net;
using easyTcp.Common.Model;
using easyTcp.Common.Model.Server;
using mudz.Server.Domain.easytcp;

namespace mudz.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var wat = new AsyncListener(new HiveMindProcessStrategy()) { Connections = new List<StateObject>() };
            wat.StartListening(IPAddress.Parse("127.0.0.1"), 4000);
        }
    }
}
