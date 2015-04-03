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
                    return new ArmyVet(name);
                case PlayerTypes.Carpenter:
                    return new Carpenter(name);
                case PlayerTypes.Mechanic:
                    return new Mechanic(name);
                case PlayerTypes.Medic:
                    return new Medic(name);
                case PlayerTypes.Politician:
                    return new Politician(name);
                default:
                    throw new NotImplementedException("Sorry. This type is not supported.");
            }
        }
    }
}
