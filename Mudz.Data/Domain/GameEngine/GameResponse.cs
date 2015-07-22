using System;
using System.Collections.Generic;
using Mudz.Data.Domain.Environment.Model;

namespace Mudz.Data.Domain.GameEngine
{
    [Serializable]
    public class GameResponse
    {
        public GameActions CurrentAction { get; set; }
        public string RequestByPlayerName { get; set; }
        public string TargetName { get; set; }
        public RoomContent RoomContent { get; set; }
        public List<ActionResult> ActionItems { get; set; }
    }
}
