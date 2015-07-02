using System;
using System.Collections.Generic;
using System.Linq;
using mudz.Common.Domain;
using mudz.Common.Domain.Environment.Map.Room;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Inventory;
using mudz.Common.Domain.Monster;
using mudz.Common.Domain.Player;

namespace mudz.Cli.Domain.GameEngine
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

        public static void DisplayCommand(ActionResult actionResult)
        {
            if (!actionResult.WasSuccessful)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                ReplaceLine(actionResult.Message);
                Console.ResetColor();

                return;
            }

            switch (actionResult.GameAction)
            {
                case GameActions.LookAround:
                    ClearScreen();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ReplaceLine(actionResult.Message);
                    Console.ResetColor();
                    break;
                case GameActions.Heal:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    ReplaceLine(actionResult.Message);
                    Console.ResetColor();
                    break;
                case GameActions.Fight:
                    Console.ForegroundColor = ConsoleColor.Red;
                    ReplaceLine(actionResult.Message);
                    Console.ResetColor();
                    break;
                case GameActions.LookAt:
                case GameActions.Login:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ReplaceLine(actionResult.Message);
                    Console.ResetColor();
                    break;
                case GameActions.Get:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ReplaceLine(actionResult.Message);
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
