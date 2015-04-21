using System.Collections.Generic;
using mudz.Core.Model.Domain.Environment.Map.Room;

namespace mudz.Core.Model.Domain.Environment.Map
{
    public class Grid
    {
        public int[][] Sheet { get;  set; }

        public Dictionary<RoomKey, RoomContent> Rooms { get; set; }  
    }
}
