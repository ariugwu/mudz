using System.Collections.Generic;
using Mudz.Common.Domain.Environment;
using Mudz.Common.Domain.Player;

namespace Mudz.Common.Domain.GameEngine
{
    public interface IActionContext
    {
        IGameRequest GameRequest { get; set; }
        IPlayer Player { get; set; }
        IGameObject Target { get; set; }
        IRoomContent Room { get; set; }
        List<IActionResult> ActionItems { get; set; }
    }
}