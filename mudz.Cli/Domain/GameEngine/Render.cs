using System;
using System.Collections.Generic;
using System.Linq;
using mudz.Core.Model.Domain;
using mudz.Core.Model.Domain.Environment.Map.Room;
using mudz.Core.Model.Domain.GameEngine;
using mudz.Core.Model.Domain.Inventory;
using mudz.Core.Model.Domain.Monster;
using mudz.Core.Model.Domain.Player;

namespace mudz.Cli.Domain.GameEngine
{
    public class Render
    {
        public static void DrawRoom(RoomContent roomContent)
        {
            // ##################################################
            // Output the title and description
            // ##################################################
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(roomContent.Title);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(roomContent.Description);
            Console.ResetColor();

            // ##################################################
            // Find all players and monsters
            // ##################################################
            List<IPlayer> players = 
                roomContent.GameObjects.Where(x => x.GameObjectType == GameObjectTypes.Player && x.GameObjectState == GameObjectStates.InPlay)
                    .Select(x => (IPlayer)x)
                    .ToList();

            List<IMonster> monsters =
                roomContent.GameObjects.Where(x => x.GameObjectType == GameObjectTypes.Monster && x.GameObjectState == GameObjectStates.InPlay)
                    .Select(x => (IMonster) x)
                    .ToList();

            // ##################################################
            // Find all inventory
            // ##################################################
            List<IInventoryItem> items =
                roomContent.GameObjects.Where(x => x.GameObjectType == GameObjectTypes.InventoryItem)
                    .Select(x => (IInventoryItem) x)
                    .ToList();

            // ##################################################
            // Output the monsters
            // ##################################################
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Targets: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine(string.Join(",", monsters.Select(x => x.Name)));

            Console.ResetColor();

            // ##################################################
            // Output the players
            // ##################################################
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Also here: ");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            
            Console.WriteLine(string.Join(",", players.Select(x => x.Name)));
            
            Console.ResetColor();

            // ##################################################
            // Output the inventory
            // ##################################################
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("On the ground: ");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(string.Join(",", items.Select(x => x.Name)));

            Console.ResetColor();
        }

        public static void DrawStatusBar(IPlayer player)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[Health: {0} | Stamina: {1}]: ", player.HitPoints, player.Stamina);
            Console.ResetColor();
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void DisplayCommand(GameResponse response)
        {
            if (!response.WasSuccessful)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                ReplaceLine(response.Message);
                Console.ResetColor();

                return;
            } 

            switch (response.Request.GameAction)
            {
                case GameActions.Heal:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    ReplaceLine(response.Message);
                    Console.ResetColor();
                    break;
                case GameActions.Fight:
                    Console.ForegroundColor = ConsoleColor.Red;
                    ReplaceLine(response.Message);
                    Console.ResetColor();
                    break;
                case GameActions.Look:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ReplaceLine(response.Message);
                    Console.ResetColor();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public static void CommandPrompt(CommandParser commandParser, HiveMind hiveMind, RoomContent room, IPlayer player)
        {
            var command = Console.ReadLine();

            commandParser.Execute(hiveMind, room, player, command);

            CommandPrompt(commandParser, hiveMind, room, player);
        }

        #region Helper(s)
        private static void ReplaceLine(string str)
        {
                Console.SetCursorPosition(0, Console.CursorTop); // Move to the start of the line.
                Console.Write(new String(' ', Console.BufferWidth - 1)); // Replace with nothing.
                Console.SetCursorPosition(0, Console.CursorTop); // Move to the start of the line.
                Console.WriteLine(str); // Replace line
        }

        public static void ClearPreviousLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new String(' ', Console.BufferWidth - 1)); // Replace with nothing.
            Console.SetCursorPosition(0, Console.CursorTop); // Move to the start of the line.
        }
        #endregion
    }
}
