using System;
using System.Collections.Generic;
using System.Linq;
using Mudz.Common.Domain.Environment;
using Mudz.Common.Domain.Player;

namespace Mudz.Data.Domain.Environment.Model
{
    [Serializable]
	public sealed class RoomCollection : Dictionary<IRoomKey, IRoomContent>, IRoomCollection
	{
		public IRoomContent Containing(IPlayer player)
		{
			return this.FirstOrDefault(x => x.Value.GameObjects.OfType<IPlayer>().Contains(player, PlayerEqualityComparer.Instance)).Value;
        }

		public IRoomContent Containing(string playerName)
		{
			return this.First(x => x.Value.GameObjects.Exists(y => y.Name.Equals(playerName, StringComparison.InvariantCultureIgnoreCase))).Value;
        }

	}
}
