using easyTcp.Common.Model;
using easyTcp.Common.Model.Client.Render;
using mudz.Core.Model.Domain.GameEngine;

namespace mudz.Cli.Domain.easytcp
{
    public class RenderStrategy : IRenderStrategy
    {
        public void Render(Response response)
        {
            var gameResponse = (GameResponse)response.Payload;

            GameEngine.Render.DisplayCommand(gameResponse);
            GameEngine.Render.DrawStatusBar(gameResponse.Player);
        }
    }
}
