using System;
using System.Collections.Generic;
using System.Linq;
using Mudz.Cli.Domain.Player;
using Mudz.Common.Domain.Monster;
using Mudz.Data.Domain;
using Mudz.Data.Domain.Environment.Model;
using Mudz.Data.Domain.GameEngine;
using Mudz.Data.Domain.Inventory;
using Mudz.Data.Domain.Player;

namespace Mudz.Cli.Domain.GameEngine
{
    public static class Render
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
                roomContent.GameObjects.Where(x => x.GameObjectType == GameObjectTypes.Player && x.GameObjectState.ToString() == GameObjectStates.InPlay.ToString())
                    .Where(x => x.Name != PlayerOne.Instance.Name)
                    .Select(x => (IPlayer)x)
                    .ToList();

            List<IMonster> monsters =
                roomContent.GameObjects.Where(x => x.GameObjectType == GameObjectTypes.Monster && x.GameObjectState.ToString() == GameObjectStates.InPlay.ToString())
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

        public static void DisplayCommand(ActionResult actionResult, string formattedMessage)
        {
            if (!actionResult.WasSuccessful)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                ReplaceLine(formattedMessage);
                Console.ResetColor();

                return;
            }

            switch (actionResult.GameAction)
            {
                case GameActions.LookAround:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ReplaceLine(formattedMessage);
                    Console.ResetColor();
                    break;
                case GameActions.Heal:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    ReplaceLine(formattedMessage);
                    Console.ResetColor();
                    break;
                case GameActions.Fight:
                    Console.ForegroundColor = ConsoleColor.Red;
                    ReplaceLine(formattedMessage);
                    Console.ResetColor();
                    break;
                case GameActions.LookAt:
                case GameActions.Login:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ReplaceLine(formattedMessage);
                    Console.ResetColor();
                    break;
                case GameActions.Get:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ReplaceLine(formattedMessage);
                    Console.ResetColor();
                    break;
                case GameActions.Die:
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
