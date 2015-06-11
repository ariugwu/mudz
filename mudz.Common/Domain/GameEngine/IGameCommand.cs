﻿namespace mudz.Common.Domain.GameEngine
{
    public interface IGameCommand
    {
        GameResponse ExecuteAction(GameRequest request);
        GameResponse ProcessItem(Inventory.IInventoryItem item);
        void CheckState();
    }
}