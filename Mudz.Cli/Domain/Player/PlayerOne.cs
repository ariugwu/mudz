
using Mudz.Common.Domain.Environment.Map.Room;
using Mudz.Common.Domain.Player;

namespace Mudz.Cli.Domain.Player
{
    public static class PlayerOne
    {
        private static IPlayer _instance = null;
        private static RoomKey _roomKey = null;

        public static RoomKey CurrenLocation
        {
            get{return _roomKey;}
            set { _roomKey = value; }
        }

        static PlayerOne()
        {
            
        }

        public static IPlayer Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }
    }
}
