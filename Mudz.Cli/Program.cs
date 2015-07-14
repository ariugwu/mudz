using System.Net;
using System.Net.Sockets;
using easyTcp.Common.Model.Client.Connection;
using Mudz.Cli.Domain.EasyTcp;

namespace Mudz.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient();

            var client = new Client(tcpClient, IPAddress.Parse("127.0.0.1"), 4000);
            var listener = new ClientListener();

            listener.StartListening((IPEndPoint)tcpClient.Client.LocalEndPoint, null, new RenderStrategy()); // Listener comes first because client is blocking.
            client.Start(tcpClient, new RenderStrategy(), new ParseStrategy());
        }
    }
}
