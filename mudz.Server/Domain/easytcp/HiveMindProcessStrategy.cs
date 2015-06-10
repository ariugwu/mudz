using easyTcp.Common.Model;
using easyTcp.Common.Model.Server;
using mudz.Core.Model.Domain.GameEngine;

namespace mudz.Server.Domain.easytcp
{
    public class HiveMindProcessStrategy : IProcessStrategy
    {
        public Response ProcessRequest(Request request)
        {
            var gameRequest = (Core.Model.Domain.GameEngine.GameRequest)request.Payload;

            var gameResponse = Core.Model.Domain.GameEngine.HiveMind.Instance.Execute(gameRequest);

            var response = new Response() {Payload = gameResponse, Type = typeof (GameResponse)};

            return response;
        }
    }
}
