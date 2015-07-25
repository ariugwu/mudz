using System;
using System.Collections.Generic;
using System.Linq;
using easyTcp.Common.Model;
using easyTcp.Common.Model.Client.Render;
using Mudz.Cli.Domain.Player;
using Mudz.Common.Domain;
using Mudz.Common.Domain.Environment;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Player;
using Mudz.Data.Domain.GameEngine;

namespace Mudz.Cli.Domain.EasyTcp
{
    public class RenderStrategy : IRenderStrategy
    {
        public void Render(Response response)
        {
            var gameResponse = (GameResponse)response.Payload;

            if (gameResponse.RoomContent != null) // If we have room content then we have a player
            {
                if (IsRequestor(gameResponse))
                {
                    LoadPlayerFromGameResponse(gameResponse); // Load the one we got back.

                    if ((gameResponse.CurrentAction == GameAction.Login ||
                        gameResponse.CurrentAction == GameAction.LookAround))
                    {
                        GameEngine.Render.ClearScreen();
                        GameEngine.Render.DrawRoom(gameResponse.RoomContent);
                    } 
                }

                DisplayActionItems(gameResponse,gameResponse.ActionItems);

                if (PlayerOne.Instance != null)
                {
                    GameEngine.Render.DrawStatusBar(PlayerOne.Instance);
                }
            }
            else
            {
                PlayerOne.Instance = null; // clear the player on a failed login
                DisplayActionItems(gameResponse,gameResponse.ActionItems); // Login failed and we should have a message.
            } 
        }

        private void LoadPlayerFromGameResponse(IGameResponse gameResponse)
        {
            PlayerOne.Instance = gameResponse.RoomContent.GameObjects.Where(x => x.GameObjectType == GameObjectType.Player && x.GameObjectState.ToString() == GameObjectState.InPlay.ToString())
        .Select(x => (IPlayer)x).FirstOrDefault(x => x.Name.Equals(PlayerOne.Instance.Name, StringComparison.InvariantCultureIgnoreCase));
            PlayerOne.CurrentLocation = gameResponse.RoomContent.RoomKey;
        }

        private void DisplayActionItems(IGameResponse gameResponse, List<IActionResult> actionItems)
        {
            foreach (var ar in actionItems)
            {
                var message = DecideMessage(gameResponse, ar);
                GameEngine.Render.DisplayCommand(ar, message);
            }
        }

        private string DecideMessage(IGameResponse gameResponse, IActionResult actionResult)
        {
            if (PlayerOne.Instance == null) return string.Empty; // Likely a login screen that's getting the message but can ignore it.

            var roomEq = new RoomKeyEqualityComparer();

            if (IsRequestor(gameResponse) && roomEq.Equals(gameResponse.RoomContent.RoomKey, PlayerOne.CurrentLocation))
            {
                return actionResult.PlayerMessage; //If the player message is null then default to the room message.
            }

            if (!IsRequestor(gameResponse) && roomEq.Equals(gameResponse.RoomContent.RoomKey, PlayerOne.CurrentLocation))
            {
                return actionResult.RoomMessage;
            }

            if (!string.IsNullOrEmpty(gameResponse.TargetName) &&
                PlayerOne.Instance.Name.Equals(gameResponse.TargetName, StringComparison.InvariantCultureIgnoreCase))
            {
                return actionResult.TargetMessage;
            }

            throw new NotImplementedException("The DecideMessage method in your RenderStrategy threw some nonsense.");
        }

        private bool IsRequestor(IGameResponse gameResponse)
        {
            return PlayerOne.Instance != null && gameResponse.RequestByPlayerName.Equals(PlayerOne.Instance.Name, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
