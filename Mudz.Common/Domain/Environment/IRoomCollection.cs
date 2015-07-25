using System.Collections.Generic;
using Mudz.Common.Domain.Player;

namespace Mudz.Common.Domain.Environment
{
    public interface IRoomCollection : IDictionary<IRoomKey, IRoomContent>
    {
        IRoomContent Containing(IPlayer player);
        IRoomContent Containing(string playerName);
    }
}