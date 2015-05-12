﻿using System;
using System.Collections.Generic;
using mudz.Core.Model.Domain.Player.Class;

namespace mudz.Core.Model.Domain.Player
{
    public static class PlayerFactory
    {
        public static IPlayer Create(string name, ActorGenderTypes gender, PlayerTypes playerType)
        {
            var player = new Player(name, gender, playerType, PlayerStrategyMap[playerType]);

            player.GameObjectKey = Guid.NewGuid();
            player.HitPoints = 10*(player.Health/13); // Run out and you die.
            player.Dexterity = 10*((player.Strength/5) + (player.Endurance/15)); // This decides how much damage you take from physical attacks.
            player.Stamina = 20; // Stamina is how you do things. Every action takes stamina (Fight, Repair, Inspect) how much stamina depends on your class and level. Once you depleated you need to rest. Every night new challenges arise in the town. Some resolve themselves and some get worse if not handled. You decide!
            
            return player;
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
