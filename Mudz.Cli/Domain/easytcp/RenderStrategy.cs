using System;
using System.Collections.Generic;
using System.Linq;
using easyTcp.Common.Model;
using easyTcp.Common.Model.Client.Render;
using Mudz.Cli.Domain.Player;
using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Player;

namespace Mudz.Cli.Domain.EasyTcp
{
    public class RenderStrategy : IRenderStrategy
    {
        public void Render(Response response)
        {
            var gameResponse = (GameResponse)response.Payload;

            if (gameResponse.RoomContent != null) // If we have room content then we have a player
            {
                LoadPlayerFromGameResponse(gameResponse); // Load the one we got back.

                if (gameResponse.CurrentAction == GameActions.Login ||
                    gameResponse.CurrentAction == GameActions.LookAround)
                {
                    GameEngine.Render.ClearScreen();
                    GameEngine.Render.DrawRoom(gameResponse.RoomContent);
                }

                DisplayActionItems(gameResponse.ActionItems);

                GameEngine.Render.DrawStatusBar(PlayerOne.Instance);
            }
            else
            {
                PlayerOne.Instance = null; // clear the player on a failed login
                DisplayActionItems(gameResponse.ActionItems); // Login failed and we should have a message.
            } 
        }

        public void LoadPlayerFromGameResponse(GameResponse gameResponse)
        {
            PlayerOne.Instance = gameResponse.RoomContent.GameObjects.Where(x => x.GameObjectType == GameObjectTypes.Player && x.GameObjectState.ToString() == GameObjectStates.InPlay.ToString())
        .Select(x => (IPlayer)x).FirstOrDefault(x => x.Name.Equals(PlayerOne.Instance.Name, StringComparison.InvariantCultureIgnoreCase));
        }

        public void DisplayActionItems(List<ActionResult> actionItems)
        {
            foreach (var ar in actionItems)
            {
                GameEngine.Render.DisplayCommand(ar);
            }
        }
    }
}
