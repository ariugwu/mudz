﻿using System;
using Mudz.Common.Domain.Npc;
using Mudz.Core.Model.Domain.Npc;

namespace Mudz.Core.Domain.Npc
{
    public class NpcFactory
    {
        public static INpc Create(string name, NpcTypes npcType)
        {
            var gameObjectKey = Guid.NewGuid();

            switch (npcType)
            {
                case NpcTypes.Deputy:
                    return new Deputy(name) { GameObjectKey = gameObjectKey };
                case NpcTypes.Sheriff:
                    return new Sheriff(name) { GameObjectKey = gameObjectKey };
                case NpcTypes.ShopKeeper:
                    return new ShopKeeper(name) { GameObjectKey = gameObjectKey };
                case NpcTypes.TownsPerson:
                    return new TownsPerson(name) { GameObjectKey = gameObjectKey };
                default:
                    throw new NotImplementedException("Sorry. This type is not supported.");
            }
        }
    }
}
