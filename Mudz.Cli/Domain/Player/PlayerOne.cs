
using Mudz.Common.Domain.Player;

namespace Mudz.Cli.Domain.Player
{
    public static class PlayerOne
    {
        private static IPlayer _instance = null;

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
