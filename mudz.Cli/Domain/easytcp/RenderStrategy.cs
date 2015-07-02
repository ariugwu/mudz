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

            var player = gameResponse.RoomContent.GameObjects.Where(x => x.GameObjectType == GameObjectTypes.Player && x.GameObjectState.ToString() == GameObjectStates.InPlay.ToString())
                    .Select(x => (IPlayer)x).FirstOrDefault(x => x.Name.Equals(PlayerOne.Instance.Name, StringComparison.InvariantCultureIgnoreCase));

            if (PlayerOne.Instance != null || player != null)
            {
                PlayerOne.Instance = player;
                GameEngine.Render.DrawRoom(gameResponse.RoomContent);

                DisplayActionItems(gameResponse.ActionItems);

                GameEngine.Render.DrawStatusBar(PlayerOne.Instance);
                return;
            }

            // We assume the login command is coming back
            if (PlayerOne.Instance == null)
            {
                DisplayActionItems(gameResponse.ActionItems); // Login failed and we should have a message.
                return;
            }
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
