using System;
using System.Collections.Generic;
using Mudz.Common.Domain.Environment.Map.Room;

namespace Mudz.Common.Domain.GameEngine
{
    [Serializable]
    public class GameResponse
    {
        public GameActions CurrentAction { get; set; }
        public RoomContent RoomContent { get; set; }
        public List<ActionResult> ActionItems { get; set; }
    }
}
