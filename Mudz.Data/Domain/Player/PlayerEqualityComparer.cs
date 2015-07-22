using System;
using System.Collections.Generic;

namespace Mudz.Data.Domain.Player
{
	public sealed class PlayerEqualityComparer : Singleton<PlayerEqualityComparer>, IEqualityComparer<IPlayer>
	{	
		public bool Equals(IPlayer x, IPlayer y)
		{
			return x.Name.Equals(y.Name, StringComparison.InvariantCultureIgnoreCase);
		}

		public int GetHashCode(IPlayer obj)
		{
			return obj.Name.GetHashCode();
		}
	}
}
