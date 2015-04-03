using System;

namespace mudz.Core.Model.Domain.Npc
{
    public class NpcFactory
    {
        public static INpc Create(string name, NpcTypes npcType)
        {
            switch (npcType)
            {
                case NpcTypes.Deputy:
                    return new Deputy(name);
                case NpcTypes.Sheriff:
                    return new Sheriff(name);
                case NpcTypes.ShopKeeper:
                    return new ShopKeeper(name);
                case NpcTypes.TownsPerson:
                    return new TownsPerson(name);
                default:
                    throw new NotImplementedException("Sorry. This type is not supported.");
            }
        }
    }
}
