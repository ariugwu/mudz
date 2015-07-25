using System;

namespace Mudz.Common.Domain
{
    [Serializable]
    public enum GameObjectType
    {
        Player,
        Npc,
        Monster,
        InventoryItem,
        EnvironmentObject
    }
}
