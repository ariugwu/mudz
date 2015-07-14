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
            return obj.X.GetHashCode()*obj.Y;
        }
    }
}
