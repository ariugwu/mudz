using System.Collections.Generic;

namespace mudz.Core.Model.Domain.Environment.Map
{
    public class Grid
    {
        public int[][] Sheet { get; set; }

        public Dictionary<RoomKey, Room> Rooms { get; set; }  
    }
}
