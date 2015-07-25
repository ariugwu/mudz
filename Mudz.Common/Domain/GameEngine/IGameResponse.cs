using System.Collections.Generic;
using Mudz.Common.Domain.Environment;

namespace Mudz.Common.Domain.GameEngine
{
    public interface IGameResponse
    {
        GameAction CurrentAction { get; set; }
        string RequestByPlayerName { get; set; }
        string TargetName { get; set; }
        IRoomContent RoomContent { get; set; }
        List<IActionResult> ActionItems { get; set; }
    }
}