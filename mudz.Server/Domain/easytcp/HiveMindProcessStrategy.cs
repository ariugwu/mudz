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
using mudz.Common.Domain.Player;

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
            catch (Exception)
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
            {"look", GameActions.LookAround},
            {"inspect", GameActions.LookAt},
            {"none", GameActions.None},
            {"get", GameActions.Get},
            {"login", GameActions.Login}
        };

        public GameResponse GetGameReponse(string command, string playerName)
        {
            GameRequest gameRequest = new GameRequest();
            GameResponse response;
            GameActions gameAction;
            IGameObject targ = null;

            if (playerName == null)
            {
                response = HiveMind.Instance.Execute(new GameRequest(){ GameAction = GameActions.Login, Sender = new Player(){ Name = command} });
            }
            else
            {
				// This is always round tripped, similar examples exist elsewhere (BaseHandler for example)
				// TODO : Contemplate a pattern to determine RoomContent and PlayerName without interlacing the two
                var room = HiveMind.Instance.World.Rooms.Containing(playerName);
                var player = GetPlayerByRoom(room, playerName);

                string[] args = command.Split(' ');
                gameAction = GetGameAction(args[0]);
                if (args.Length > 2) gameAction = GameActions.None;
                if (args.Length == 2) targ = GetTarget(room, args[1]);

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
            return room.GameObjects.First(x => x.Name.Trim().Equals(targetName, StringComparison.InvariantCultureIgnoreCase));
        }

        private IPlayer GetPlayerByRoom(RoomContent room, string playerName)
        {
            return room.GameObjects.OfType<IPlayer>().First(x => x.Name.Equals(playerName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
