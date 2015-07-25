
using Mudz.Common.Domain.Environment;
using Mudz.Common.Domain.Player;

namespace Mudz.Cli.Domain.Player
{
	public static class PlayerOne
    {
        private static IPlayer _instance = null;
        private static IRoomKey _roomKey = null;

        public static IRoomKey CurrentLocation
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
