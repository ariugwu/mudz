using System;
using System.Collections.Generic;
using easyTcp.Common.Model;
using easyTcp.Common.Model.Server;
using Mudz.Core.Domain.GameEngine;
using Mudz.Data.Domain.EasyTcp;
using Mudz.Data.Domain.GameEngine;

namespace Mudz.Server.Domain.EasyTcp
{
	public class ConsoleProcessStrategy : IProcessStrategy
    {
        public Dictionary<StateObject, Response> ProcessRequest(StateObject thisConnection, List<StateObject> allConnections, Request request)
        {
            var consoleRequest = (ConsoleRequest)request.Payload;

            GameResponse gameResponse;

            try
            {
                gameResponse = GetGameReponse(consoleRequest.Command, consoleRequest.PlayerName);
            }
            catch (Exception)
            {
                gameResponse = new GameResponse(){ActionItems = new List<ActionResult>()};
                
                var actionResult = new ActionResult()
                {
                    PlayerMessage = "Whoops! Something went hella wrong. Please try again.",
                    WasSuccessful = false
                };

                gameResponse.ActionItems.Add(actionResult);
            }

            var broadCastList = new Dictionary<StateObject, Response>();
            var response = new Response() { Payload = gameResponse, Type = typeof(GameResponse) };

            foreach (var c in allConnections)
            {
                broadCastList.Add(c, response);
            }

            return broadCastList;
        }

        public GameResponse GetGameReponse(string command, string playerName)
        {
            var gameRequest = new GameRequest(playerName);

            gameRequest.Interpret(command);

            return HiveMind.Instance.Execute(gameRequest);
        }

    }
}
