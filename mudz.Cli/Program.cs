
using System.Linq;
using System.Net;
using mudz.Cli.Domain.easytcp;
using mudz.Cli.Domain.GameEngine;
using mudz.Core.Model.Domain.GameEngine;
using mudz.Core.Model.Domain.Player;

namespace mudz.Cli
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create our new game engine
            var hiveMind = HiveMind.Instance;

            // Grab the first room from the seeded content. @SEE -> HiveMind.SeedWorld()
            var room = hiveMind.World.Rooms.First().Value;

            // Create two players to test with.
            var gary = (IPlayer)room.GameObjects.First(x => x.Name == "Gary");

                //gary.AddInventoryItem(new TestCharm());

            var commandParser = new CommandParser();

            Render.DrawRoom(room);
            Render.DrawStatusBar(gary);
            Render.CommandPrompt(commandParser, hiveMind, room, gary);

            //var client = new easyTcp.Common.Model.Client.Connection.Client();
            //client.Start(IPAddress.Parse("127.0.0.1"), 4000, new RenderStrategy(), new ParseStrategy());

        }
    }
}
