using System.Collections.Generic;
using Mudz.Common.Domain;
using Mudz.Common.Domain.Environment;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Player;

namespace Mudz.Data.Domain.GameEngine
{
    public class ActionContext : IActionContext
    {
        public IGameRequest GameRequest { get; set; }

        public IPlayer Player { get; set; }
        public IGameObject Target { get; set; }
        public IRoomContent Room { get; set; }
        public List<IActionResult> ActionItems { get; set; }
    }
}
