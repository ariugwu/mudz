using System;
using System.Collections.Generic;
using System.Linq;
using mudz.Core.Model.Domain;
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
            else if (command.Trim().ToLower() == "look")
            {
                Render.ClearScreen();
                Render.DrawRoom(room);
                response = new GameResponse(){ Amount = 0, Message = String.Format("{0} looks around.", player.Name)};
            }
            else if (command.StartsWith("look"))
            {
                var targetName = command.Replace("look", string.Empty).Trim();
                var target = room.GameObjects.First(x => x.Name.ToLower().Trim() == targetName);
                response = hiveMind.Execute(new GameRequest() { GameAction = GameActions.Look, Sender = player, Target = target });
            }
            else if (command.StartsWith("get"))
            {
                throw new NotImplementedException();
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
            Render.DrawStatusBar(player);
        }

        private Dictionary<string, GameActions> _commandActionMap = new Dictionary<string, GameActions>()
        {
            {"fight", GameActions.Fight},
            {"negotiate", GameActions.Negotiate},
            {"repair", GameActions.Repair},
            {"heal", GameActions.Heal},
            {"look", GameActions.Look},
            {"none", GameActions.None}
        };

        public GameResponse GetGameReponse(string command, HiveMind hiveMind, RoomContent room, IGameObject player)
        {
            GameResponse response;

            string[] args = command.Split(' ');
            GameActions gameAction = GetGameAction(args[0]);

            if (args.Length > 1 || gameAction == GameActions.None)
            {
                response = NoSuitableCommand(player);
            }
            else
            {
                IGameObject targ = GetTarget(room, args[1]);
                response = hiveMind.Execute(new GameRequest() { GameAction = gameAction, Sender = player, Target = targ });
            }

            return response;
        }

        public GameActions GetGameAction(string command)
        {
            command = command.Trim().ToLower();
            return (_commandActionMap.ContainsKey(command))? _commandActionMap[command] : GameActions.None;
        }

        public IGameObject GetTarget(RoomContent room, string targetName)
        {
            return room.GameObjects.First(x => x.Name.ToLower().Trim() == targetName);
        }

        public GameResponse NoSuitableCommand(IGameObject player)
        {
            return new GameResponse()
                {
                    Message = "Sorry, no command matched your request.",
                    WasSuccessful = false,
                    Request = new GameRequest() { GameAction = GameActions.None, Sender = player, Target = null}
                };
        }
    }


}
