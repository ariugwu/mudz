
using System.Linq;
using System.Net;
using mudz.Cli.Domain.easytcp;
using mudz.Cli.Domain.GameEngine;

namespace mudz.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            //Render.DrawRoom(room);
            //Render.DrawStatusBar(gary);
            //Render.CommandPrompt(commandParser, hiveMind, room, gary);

            var client = new easyTcp.Common.Model.Client.Connection.Client();
            client.Start(IPAddress.Parse("127.0.0.1"), 4000, new RenderStrategy(), new ParseStrategy());

        }
    }
}
