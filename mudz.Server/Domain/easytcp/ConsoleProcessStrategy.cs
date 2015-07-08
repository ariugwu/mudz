using System;
using System.Collections.Generic;
using easyTcp.Common.Model;
using easyTcp.Common.Model.Server;
using Mudz.Common.Domain.EasyTcp;
using Mudz.Common.Domain.GameEngine;
using Mudz.Core.Domain.GameEngine;

namespace Mudz.Server.Domain.EasyTcp
{
    public class ConsoleProcessStrategy : IProcessStrategy
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
                gameResponse = new GameResponse(){ActionItems = new List<ActionResult>()};
                
                var actionResult = new ActionResult()
                {
                    Message = "Whoops! Something went hella wrong. Please try again.",
                    WasSuccessful = false
                };

                gameResponse.ActionItems.Add(actionResult);
            }

            var response = new Response() { Payload = gameResponse, Type = typeof(GameResponse) };

            return response;
        }

        public GameResponse GetGameReponse(string command, string playerName)
        {
            var gameRequest = new GameRequest(playerName);

            gameRequest.Interpret(command);

            return HiveMind.Instance.Execute(gameRequest);
        }

    }
}
