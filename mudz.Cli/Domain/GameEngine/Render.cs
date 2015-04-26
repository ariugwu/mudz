using System;
using System.Collections.Generic;
using System.Linq;
using mudz.Core.Model.Domain;
using mudz.Core.Model.Domain.Environment.Map.Room;
using mudz.Core.Model.Domain.GameEngine;
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
            
            Console.WriteLine(string.Join(",", players.Select(x => x.Name)));
            
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void DrawStatusBar(IPlayer player)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[Health: {0} | Stamina: {1}]: ", player.HitPoints, "N/A");
            Console.ResetColor();
        }

        public static void DisplayCommand(GameResponse response)
        {
            switch (response.Request.GameAction)
            {
                case GameActions.Heal:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    ReplaceLastLine(response.Message);
                    Console.ResetColor();
                    break;
                default:
                    throw new NotImplementedException();
            }
            
            DrawStatusBar((IPlayer)response.Request.Sender);
        }

        private static void ReplaceLastLine(string str)
        {
                Console.SetCursorPosition(0, Console.CursorTop); // Move to the start of the line.
                Console.Write(new String(' ', Console.BufferWidth - 1)); // Replace with nothing.
                Console.SetCursorPosition(0, Console.CursorTop); // Move to the start of the line.
                Console.WriteLine(str); // Replace line
        }
    }
}
