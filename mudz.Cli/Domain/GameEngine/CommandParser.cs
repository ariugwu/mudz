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

            try
            {
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
                else
                {
                    // Check to see if the command is asking for one of the following: Look at target, fight, heal, repair, negotiate
                    response = GetGameReponse(command, hiveMind, room, player);
                }
            }
            catch (Exception ex)
            {
                response = ExceptionGameResponse(player);
            }

            Render.DisplayCommand(response);
            Render.DrawStatusBar(player);

        }

        private Dictionary<string, GameActions> _commandActionMap = new Dictionary<string, GameActions>()
        {
            {"fight", GameActions.Fight},
            {"attack", GameActions.Fight},
            {"negotiate", GameActions.Negotiate},
            {"repair", GameActions.Repair},
            {"heal", GameActions.Heal},
            {"look", GameActions.Look},
            {"none", GameActions.None},
            {"get", GameActions.Get}
        };

        public GameResponse GetGameReponse(string command, HiveMind hiveMind, RoomContent room, IGameObject player)
        {
            GameResponse response;

            string[] args = command.Split(' ');
            GameActions gameAction = GetGameAction(args[0]);

            if (args.Length > 2 || gameAction == GameActions.None)
            {
                response = NoSuitableCommand(player);
            }
            else
            {
                IGameObject targ = GetTarget(room, args[1]);
                response = hiveMind.Execute(new GameRequest() { RoomKey = room.RoomKey, GameAction = gameAction, Sender = player, Target = targ });
            }

            return response;
        }

        public GameActions GetGameAction(string command)
        {
            command = command.Trim().ToLower();

            return (_commandActionMap.ContainsKey(command)) ? _commandActionMap[command] : GameActions.None;
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
                    Request = new GameRequest() { GameAction = GameActions.None, Sender = player, Target = null }
                };
        }

        public GameResponse ExceptionGameResponse(IGameObject player)
        {
            return new GameResponse()
            {
                Message = "Whoops! Something went hella wrong. Please try again.",
                WasSuccessful = false,
                Request = new GameRequest() { GameAction = GameActions.None, Sender = player, Target = null }
            };
        }
    }


}
