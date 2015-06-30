using System.Collections.Generic;
using mudz.Common.Domain.Environment.Map.Room;

namespace mudz.Common.Domain.Environment.Map
{
    public class Grid
    {
        public int[][] Sheet { get;  set; }

        public RoomCollection Rooms { get; set; }  
    }
}
