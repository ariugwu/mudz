using System;

namespace mudz.Common.Domain.Environment.Map.Room
{
    [Serializable]
    public class RoomKey
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
