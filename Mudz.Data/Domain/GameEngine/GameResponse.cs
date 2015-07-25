using System;
using System.Collections.Generic;
using Mudz.Common.Domain.Environment;
using Mudz.Common.Domain.GameEngine;

namespace Mudz.Data.Domain.GameEngine
{
    [Serializable]
    public class GameResponse : IGameResponse
    {
        public GameAction CurrentAction { get; set; }
        public string RequestByPlayerName { get; set; }
        public string TargetName { get; set; }
        public IRoomContent RoomContent { get; set; }
        public List<IActionResult> ActionItems { get; set; }
    }
}
