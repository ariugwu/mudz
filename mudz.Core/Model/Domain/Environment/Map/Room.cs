using System.Collections.Generic;
namespace mudz.Core.Model.Domain.Environment.Map
{
    public class Room
    {
        public RoomKey RoomKey { get; set; }
        public IEnumerable<RoomObject> RoomObjects { get; set; }
    }
}
