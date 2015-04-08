using System;

namespace mudz.Core.Model.Domain.Player
{
    public class PlayerFactory
    {
        public static IPlayer Create(string name, PlayerTypes playerType)
        {
            switch (playerType)
            {
                case PlayerTypes.ArmyVet:
                    return new Player(name, playerType, new ArmyVet());
                case PlayerTypes.Carpenter:
                    return new Player(name, playerType, new Carpenter());
                case PlayerTypes.Mechanic:
                    return new Player(name, playerType, new Mechanic());
                case PlayerTypes.Medic:
                    return new Player(name, playerType, new Medic());
                case PlayerTypes.Politician:
                    return new Player(name, playerType, new Politician());
                default:
                    throw new NotImplementedException("Sorry. This type is not supported.");
            }
        }
    }
}
