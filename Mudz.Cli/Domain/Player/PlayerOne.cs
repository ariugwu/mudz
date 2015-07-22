
using Mudz.Data.Domain.Environment.Model;
using Mudz.Data.Domain.Player;

namespace Mudz.Cli.Domain.Player
{
	public static class PlayerOne
    {
        private static IPlayer _instance = null;
        private static RoomKey _roomKey = null;

        public static RoomKey CurrentLocation
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
