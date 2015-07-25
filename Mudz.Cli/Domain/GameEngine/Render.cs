using System;
using System.Collections.Generic;
using System.Linq;
using Mudz.Cli.Domain.Player;
using Mudz.Common.Domain;
using Mudz.Common.Domain.Environment;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Inventory;
using Mudz.Common.Domain.Monster;
using Mudz.Common.Domain.Player;

namespace Mudz.Cli.Domain.GameEngine
{
    public static class Render
    {
        public static void DrawRoom(IRoomContent roomContent)
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
                roomContent.GameObjects.Where(x => x.GameObjectType == GameObjectType.Player && x.GameObjectState.ToString() == GameObjectState.InPlay.ToString())
                    .Where(x => x.Name != PlayerOne.Instance.Name)
                    .Select(x => (IPlayer)x)
                    .ToList();

            List<IMonster> monsters =
                roomContent.GameObjects.Where(x => x.GameObjectType == GameObjectType.Monster && x.GameObjectState.ToString() == GameObjectState.InPlay.ToString())
                    .Select(x => (IMonster) x)
                    .ToList();

            // ##################################################
            // Find all inventory
            // ##################################################
            List<IInventoryItem> items =
                roomContent.GameObjects.Where(x => x.GameObjectType == GameObjectType.InventoryItem)
                    .Select(x => (IInventoryItem) x)
                    .ToList();

            // ##################################################
            // Output the monsters
            // ##################################################
            if (monsters.Any())
            { 
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Targets: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine(string.Join(",", monsters.Select(x => x.Name)));

                Console.ResetColor();
            }

            // ##################################################
            // Output the players
            // ##################################################
            if (players.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Also here: ");

                Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.WriteLine(string.Join(",", players.Select(x => x.Name)));

                Console.ResetColor();
            }


            // ##################################################
            // Output the inventory
            // ##################################################
            if (items.Any())
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("On the ground: ");

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(string.Join(",", items.Select(x => x.Name)));

                Console.ResetColor();
            }
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

        public static void DisplayCommand(IActionResult actionResult, string formattedMessage)
        {
            if (string.IsNullOrEmpty(formattedMessage)) return;

            if (!actionResult.WasSuccessful)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                ReplaceLine(formattedMessage);
                Console.ResetColor();

                return;
            }

            switch (actionResult.GameAction)
            {
                case GameAction.LookAround:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ReplaceLine(formattedMessage);
                    Console.ResetColor();
                    break;
                case GameAction.Heal:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    ReplaceLine(formattedMessage);
                    Console.ResetColor();
                    break;
                case GameAction.Fight:
                    Console.ForegroundColor = ConsoleColor.Red;
                    ReplaceLine(formattedMessage);
                    Console.ResetColor();
                    break;
                case GameAction.LookAt:
                case GameAction.Login:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ReplaceLine(formattedMessage);
                    Console.ResetColor();
                    break;
                case GameAction.Get:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ReplaceLine(formattedMessage);
                    Console.ResetColor();
                    break;
                case GameAction.Die:
                    Console.ForegroundColor = ConsoleColor.Green;
                    ReplaceLine(formattedMessage);
                    Console.ResetColor();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        #region Helper(s)
        private static void ReplaceLine(string str)
        {
                Console.SetCursorPosition(0, Console.CursorTop); // Move to the start of the line.
                Console.Write(new string(' ', Console.BufferWidth - 1)); // Replace with nothing.
                Console.SetCursorPosition(0, Console.CursorTop); // Move to the start of the line.
                Console.WriteLine(str); // Replace line
        }

        public static void ClearPreviousLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth - 1)); // Replace with nothing.
            Console.SetCursorPosition(0, Console.CursorTop); // Move to the start of the line.
        }
        #endregion
    }
}
