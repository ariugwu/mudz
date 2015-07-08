using System.Collections.Generic;
using Mudz.Common.Domain.Environment.Map.Room;

namespace Mudz.Common.Domain.Environment.Map
{
    public class Grid
    {
        public int[][] Sheet { get;  set; }

        public RoomCollection Rooms { get; set; }  
    }
}
