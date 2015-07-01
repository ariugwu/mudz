using System.Collections.Generic;
using mudz.Common.Domain.Player;

namespace mudz.Common.Domain.GameEngine
{
    public class ActionContext
    {
        public IPlayer Player { get; set; }
        public IGameObject Target { get; set; }
        public List<ActionItem> ActionItems { get; set; }

        public GameActions CurrentAction { get; set; }
    }
}
