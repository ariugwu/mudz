using System;
using System.Collections.Generic;
using System.Linq;
using easyTcp.Common.Model;
using easyTcp.Common.Model.Client.Render;
using mudz.Cli.Domain.Player;
using mudz.Common.Domain;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Player;

namespace mudz.Cli.Domain.easytcp
{
    public class RenderStrategy : IRenderStrategy
    {
        public void Render(Response response)
        {
            var gameResponse = (GameResponse)response.Payload;

            if (gameResponse.RoomContent != null)
            {
                LoadPlayerFromGameResponse(gameResponse); // Load the one we got back.

                if (gameResponse.CurrentAction == GameActions.Login || gameResponse.CurrentAction == GameActions.LookAround)
                {
                    GameEngine.Render.ClearScreen();
                    GameEngine.Render.DrawRoom(gameResponse.RoomContent);
                }

                DisplayActionItems(gameResponse.ActionItems);

                GameEngine.Render.DrawStatusBar(PlayerOne.Instance);
                return;
            }

            DisplayActionItems(gameResponse.ActionItems); // Login failed and we should have a message.
            if (gameResponse.CurrentAction != GameActions.Login)
            {
                GameEngine.Render.DrawStatusBar(PlayerOne.Instance);
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
