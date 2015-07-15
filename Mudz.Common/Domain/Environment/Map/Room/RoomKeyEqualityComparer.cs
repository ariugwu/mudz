using System.Collections.Generic;

namespace Mudz.Common.Domain.Environment.Map.Room
{
    public sealed class RoomKeyEqualityComparer : IEqualityComparer<RoomKey>
    {
        public bool Equals(RoomKey x, RoomKey y)
        {
            return x.X.Equals(y.X) && x.Y.Equals(y.Y);
        }

        public int GetHashCode(RoomKey obj)
        {
			unchecked
			{
				int hash = 17;
				hash = hash * 23 + obj.X.GetHashCode();
				hash = hash * 23 + obj.Y.GetHashCode();
				return hash;
			}
        }
    }
}
