using System;
using easyTcp.Common.Model;
using easyTcp.Common.Model.Client.Render;
using mudz.Cli.Domain.Player;
using mudz.Common.Domain.GameEngine;

namespace mudz.Cli.Domain.easytcp
{
    public class RenderStrategy : IRenderStrategy
    {
        public void Render(Response response)
        {
            var gameResponse = (GameResponse)response.Payload;

            if (PlayerOne.Instance == null && gameResponse.WasSuccessful)
            {
                PlayerOne.Instance = gameResponse.Player;
                GameEngine.Render.DrawRoom(gameResponse.RoomContent);
                GameEngine.Render.DisplayCommand(gameResponse);
                GameEngine.Render.DrawStatusBar(PlayerOne.Instance);
            }
            else
            {
                PlayerOne.Instance = gameResponse.Player;
                GameEngine.Render.DisplayCommand(gameResponse);
                GameEngine.Render.DrawStatusBar(PlayerOne.Instance);
            }
        }
    }
}
