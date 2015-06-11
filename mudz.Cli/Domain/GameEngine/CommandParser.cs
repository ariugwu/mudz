using System;
using mudz.Common.Domain.Environment.Map.Room;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Player;

namespace mudz.Cli.Domain.GameEngine
{
    public class CommandParser
    {
        public void Execute(RoomContent room, IPlayer player, string command)
        {
            GameResponse response;

            // If they are just looking at the room then handle that and exit.
            if (command.Trim().ToLower() == "look")
            {
                Render.ClearScreen();
                Render.DrawRoom(room);
                response = new GameResponse()
                {
                    Amount = 0,
                    Message = String.Format("{0} looks around.", player.Name)
                };
            }

        }
    }


}
