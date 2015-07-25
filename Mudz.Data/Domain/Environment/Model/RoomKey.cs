using System;
using Mudz.Common.Domain.Environment;

namespace Mudz.Data.Domain.Environment.Model
{
    [Serializable]
    public class RoomKey : IRoomKey
    {
        public RoomKey(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
