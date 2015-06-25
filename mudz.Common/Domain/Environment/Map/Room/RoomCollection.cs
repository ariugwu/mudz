using mudz.Common.Domain.Player;
using System.Collections.Generic;
using System.Linq;

namespace mudz.Common.Domain.Environment.Map.Room
{
	public sealed class RoomCollection : Dictionary<RoomKey, RoomContent>
	{
		public RoomContent Containing(IPlayer player)
		{
			return this.FirstOrDefault(x => x.Value.GameObjects.OfType<IPlayer>().Contains(player, PlayerEqualityComparer.Instance)).Value;
        }
	}
}
