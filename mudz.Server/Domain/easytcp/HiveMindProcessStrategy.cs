using System;
using System.Collections.Generic;
using System.Linq;
using easyTcp.Common.Model;
using easyTcp.Common.Model.Server;
using mudz.Common.Domain;
using mudz.Common.Domain.easytcp;
using mudz.Common.Domain.Environment.Map.Room;
using mudz.Common.Domain.GameEngine;
using mudz.Core.Model.Domain.GameEngine;
using mudz.Core.Model.Domain.Player;

namespace mudz.Server.Domain.easytcp
{
    public class HiveMindProcessStrategy : IProcessStrategy
    {
        public Response ProcessRequest(Request request)
        {
            var consoleRequest = (ConsoleRequest)request.Payload;

            GameResponse gameResponse;

            try
            {
                gameResponse = GetGameReponse(consoleRequest.Command, consoleRequest.PlayerName);
            }
            catch (Exception ex)
            {
                gameResponse = new GameResponse()
                {
                    Message = "Whoops! Something went hella wrong. Please try again.",
                    WasSuccessful = false,
                    Request = new GameRequest() { GameAction = GameActions.None, Target = null }
                };
            }

            var response = new Response() { Payload = gameResponse, Type = typeof(GameResponse) };

            return response;
        }

        private Dictionary<string, GameActions> _commandActionMap = new Dictionary<string, GameActions>()
        {
            {"fight", GameActions.Fight},
            {"attack", GameActions.Fight},
            {"negotiate", GameActions.Negotiate},
            {"repair", GameActions.Repair},
            {"heal", GameActions.Heal},
            {"look", GameActions.LookAt},
            {"none", GameActions.None},
            {"get", GameActions.Get},
            {"login", GameActions.Login}
        };

        public GameResponse GetGameReponse(string command, string playerName)
        {
            GameResponse response;
            GameActions gameAction;

            if (playerName == null)
            {
                response = HiveMind.Instance.Execute(new GameRequest(){ GameAction = GameActions.Login, Sender = new Player(){ Name = command} });
            }
            else
            {
                var room = HiveMind.Instance.World.Rooms.First(x => x.Value.GameObjects.Exists(y => y.Name.ToLower().Equals(playerName.ToLower()))).Value;

                var player = GetPlayerByRoom(room, playerName);

                string[] args = command.Split(' ');

                gameAction = GetGameAction(args[0]);

                if (args.Length > 2) gameAction = GameActions.None;

                IGameObject targ = GetTarget(room, args[1]);

                response = HiveMind.Instance.Execute(new GameRequest() { RoomKey = room.RoomKey, GameAction = gameAction, Sender = player, Target = targ });

            }

            return response;
        }

        private GameActions GetGameAction(string command)
        {
            command = command.Trim().ToLower();

            return (_commandActionMap.ContainsKey(command)) ? _commandActionMap[command] : GameActions.None;
        }

        private IGameObject GetTarget(RoomContent room, string targetName)
        {
            return room.GameObjects.First(x => x.Name.ToLower().Trim() == targetName);
        }

        private IGameObject GetPlayerByRoom(RoomContent room, string playerName)
        {
            return room.GameObjects.First(x => x.Name.ToLower().Equals(playerName.ToLower()));
        }
    }
}
