﻿namespace mudz.Core.Model.Domain.Inventory
{
    public interface IInventoryItem : IGameObject
    {
        InventoryTypes InventoryType { get; }
    }
}
