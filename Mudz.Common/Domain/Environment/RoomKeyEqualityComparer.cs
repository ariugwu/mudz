using System.Collections.Generic;

namespace Mudz.Common.Domain.Environment
{
    public sealed class RoomKeyEqualityComparer : IEqualityComparer<IRoomKey>
    {
        public bool Equals(IRoomKey x, IRoomKey y)
        {
            return x.X.Equals(y.X) && x.Y.Equals(y.Y);
        }

        public int GetHashCode(IRoomKey obj)
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
