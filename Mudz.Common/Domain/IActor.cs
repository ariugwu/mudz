﻿using Mudz.Common.Domain.Player.Inventory;
using Mudz.Data.Domain.Player.Inventory;

namespace Mudz.Common.Domain
{
    public interface IActor : IGameObject
    {
        ActorGenderType Gender  { get; set; }

        int Health { get; set; }
        int Stamina { get; set; }

        int Strength { get; set; }
        int Intellect { get; set; }
        int Wisdom { get; set; }
        int Agility { get; set; }
        int Willpower { get; set; }
        int Charm { get; set; }
        int Endurance { get; set; }

        string GetDescription();

        void EquipWeapon(IPlayerWeapon weapon);

        void EquipWearable(IPlayerWearable wearable);
    }
}
