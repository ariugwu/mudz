using System.Collections.Generic;

namespace mudz.Core.Model.Domain.Player
{
    public static class PlayerFactory
    {
        public static IPlayer Create(string name, PlayerTypes playerType)
        {
            return new Player(name, playerType, PlayerStrategyMap[playerType]);
        }

        public static Dictionary<PlayerTypes, IPlayerActionStrategy> PlayerStrategyMap = 
            new Dictionary<PlayerTypes, IPlayerActionStrategy>()
            {
                {PlayerTypes.ArmyVet, new ArmyVet()},
                {PlayerTypes.Carpenter, new Carpenter()},
                {PlayerTypes.Mechanic, new Mechanic()},
                {PlayerTypes.Medic, new Medic()},
                {PlayerTypes.Politician, new Politician()}
            };
    }
}
