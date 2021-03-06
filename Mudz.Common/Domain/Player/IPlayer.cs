﻿using System.Collections.Generic;
using Mudz.Common.Domain.Player.Inventory;
using Mudz.Data.Domain.Player.Inventory;

namespace Mudz.Common.Domain.Player
{
    public interface IPlayer: IGameObject
    {
        PlayerTypes PlayerType { get; set; }
        IList<IPlayerInventoryItem> Inventory { get; }

        int Stamina { get; set; }

        string GetName();

        string GetDescription();

        void AddInventoryItem(IPlayerInventoryItem item);

        void RemoveInventoryItem(int index);

        void SetState(ActorState actorState);

    }
}
