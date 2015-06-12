using System.Net;
using mudz.Cli.Domain.easytcp;

namespace mudz.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new easyTcp.Common.Model.Client.Connection.Client();
            client.Start(IPAddress.Parse("127.0.0.1"), 4000, new RenderStrategy(), new ParseStrategy());
        }
    }
}
