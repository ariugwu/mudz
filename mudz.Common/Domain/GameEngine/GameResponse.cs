using System;
using System.Collections.Generic;
using mudz.Common.Domain.Environment.Map.Room;

namespace mudz.Common.Domain.GameEngine
{
    [Serializable]
    public class GameResponse
    {
        public RoomContent RoomContent { get; set; }
        public List<ActionResult> ActionItems { get; set; }
    }
}
