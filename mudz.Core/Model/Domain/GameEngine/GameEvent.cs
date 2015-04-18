using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mudz.Core.Model.Domain.GameEngine
{
    public class GameEvent
    {
        public GameRequest GameRequest { get; set; }
        public GameResponse GameResponse { get; set; }
    }
}
