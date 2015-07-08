using Mudz.Common.Domain.Player;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mudz.Common.Domain.Environment.Map.Room
{
	public sealed class RoomCollection : Dictionary<RoomKey, RoomContent>
	{
		public RoomContent Containing(IPlayer player)
		{
			return this.FirstOrDefault(x => x.Value.GameObjects.OfType<IPlayer>().Contains(player, PlayerEqualityComparer.Instance)).Value;
        }

		public RoomContent Containing(string playerName)
		{
			return this.First(x => x.Value.GameObjects.Exists(y => y.Name.Equals(playerName, StringComparison.InvariantCultureIgnoreCase))).Value;
        }
	}
}
