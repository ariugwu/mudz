using System.Collections.Generic;
using Mudz.Data.Domain.Environment.Model;
using Mudz.Data.Domain.Player;

namespace Mudz.Data.Domain.GameEngine
{
    public class ActionContext
    {
        public GameRequest GameRequest { get; set; }

        public IPlayer Player { get; set; }
        public IGameObject Target { get; set; }
        public RoomContent Room { get; set; }
        public List<ActionResult> ActionItems { get; set; }
    }
}
