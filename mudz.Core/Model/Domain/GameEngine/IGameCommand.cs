using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mudz.Core.Model.Domain.GameEngine
{
    public interface IGameCommand
    {
        GameResponse Execute(GameRequest request);
    }
}
