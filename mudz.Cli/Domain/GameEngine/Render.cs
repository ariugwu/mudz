using System;
using System.Collections.Generic;
using System.Linq;
using mudz.Core.Model.Domain;
using mudz.Core.Model.Domain.Environment.Map.Room;
using mudz.Core.Model.Domain.Monster;
using mudz.Core.Model.Domain.Player;

namespace mudz.Cli.Domain.GameEngine
{
    public class Render
    {
        public static void DrawRoom(RoomContent roomContent)
        {
            // Output the title and description
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(roomContent.Title);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(roomContent.Description);
            Console.ResetColor();

            // Find all players and monsters
            List<IPlayer> players = 
                roomContent.GameObjects.Where(x => x.GameObjectType == GameObjectTypes.Player)
                    .Select(x => (IPlayer)x)
                    .ToList();

            List<IMonster> monsters =
                roomContent.GameObjects.Where(x => x.GameObjectType == GameObjectTypes.Monster)
                    .Select(x => (IMonster) x)
                    .ToList();

            // Output the monsters
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Targets: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (var m in monsters)
            {
                Console.Write(m.Name + ",");
            }
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Also here: ");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            foreach (var p in players)
            {
                Console.Write(p.Name + ",");
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.
        }

        public static void DrawStatusBar(IPlayer player)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[Health: {0} | Stamina: {1}]: ", player.HitPoints, "N/A");
            Console.ResetColor();
        }
    }
}
