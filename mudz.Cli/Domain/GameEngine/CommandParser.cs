using System;
using System.Linq;
using mudz.Core.Model.Domain.Environment.Map.Room;
using mudz.Core.Model.Domain.GameEngine;
using mudz.Core.Model.Domain.Player;

namespace mudz.Cli.Domain.GameEngine
{
    public class CommandParser
    {
        public void Execute(HiveMind hiveMind, RoomContent room, IPlayer player, string command)
        {
            GameResponse response;

            if (command.StartsWith("fight"))
            {
                var targetName = command.Replace("fight", string.Empty).ToLower().Trim();
                var target = room.GameObjects.First(x => x.Name.ToLower().Trim() == targetName);
                response = hiveMind.Execute(new GameRequest() { GameAction = GameActions.Fight, Sender = player, Target = target });
            }
            else if (command.StartsWith("negotiate"))
            {
                var targetName = command.Replace("negotiate", string.Empty).Trim();
                var target = room.GameObjects.First(x => x.Name.ToLower().Trim() == targetName);
                response = hiveMind.Execute(new GameRequest() { GameAction = GameActions.Negotiate, Sender = player, Target = target });
            }
            else if (command.StartsWith("repair"))
            {
                var targetName = command.Replace("repair", string.Empty).Trim();
                var target = room.GameObjects.First(x => x.Name.ToLower().Trim() == targetName);
                response = hiveMind.Execute(new GameRequest() { GameAction = GameActions.Repair, Sender = player, Target = target });
            }
            else if (command.StartsWith("heal"))
            {
                var targetName = command.Replace("heal", string.Empty).Trim();
                var target = room.GameObjects.First(x => x.Name.ToLower().Trim() == targetName);
                response = hiveMind.Execute(new GameRequest() { GameAction = GameActions.Heal, Sender = player, Target = target });
            }
            else if (command.StartsWith("look"))
            {
                var targetName = command.Replace("look", string.Empty).Trim();
                var target = room.GameObjects.First(x => x.Name.ToLower().Trim() == targetName);
                response = hiveMind.Execute(new GameRequest() { GameAction = GameActions.Look, Sender = player, Target = target });
            }
            else
            {
                response = new GameResponse()
                {
                    Message = "Sorry, no command matched your request.",
                    WasSuccessful = false,
                    Request = new GameRequest() { GameAction = GameActions.None, Sender = player, Target = null}
                };
            }

            Render.ClearPreviousLine();
            Render.DisplayCommand(response);
            Render.DrawStatusBar((IPlayer)response.Request.Sender);
        }
    }
}
