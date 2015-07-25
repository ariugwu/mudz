using System;
using System.Collections.Generic;
using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Player;
using Mudz.Data.Domain;
using Mudz.Data.Domain.GameEngine;

namespace Mudz.Core.Model.Domain.Player.Class
{
    [Serializable]
    public class Mechanic : IPlayerActionStrategy
    {
        private Dictionary<GameAction, int> _actionStaminaCostMap = new Dictionary<GameAction, int>()
        {
            {GameAction.Fight, 2},
            {GameAction.Heal, 3},
            {GameAction.Repair, 1},
            {GameAction.Negotiate, 2}
        };

        public Dictionary<GameAction, int> ActionStaminaCostMap
        {
            get { return _actionStaminaCostMap; }
        } 

        public void SetStats(IActor actor)
        {
            actor.Health = 185;
            actor.Strength = 145;
            actor.Intellect = 80;
            actor.Wisdom = 65;
            actor.Agility = 145;
            actor.Willpower = 150;
            actor.Charm = 40;
            actor.Endurance = 165;
        }

        public int Attack(IActor actor)
        {
            AdjustStamina(actor, ActionStaminaCostMap[GameAction.Fight]);
            return 7;
        }

        public int Heal(IActor actor)
        {
            AdjustStamina(actor, ActionStaminaCostMap[GameAction.Heal]);
            return 5;
        }

        public int Repair(IActor actor)
        {
            AdjustStamina(actor, ActionStaminaCostMap[GameAction.Repair]);
            return 10;
        }

        public int Negotiate(IActor actor)
        {
           AdjustStamina(actor, ActionStaminaCostMap[GameAction.Negotiate]);
            return 10;
        }

        public void TakeDamage(IActor actor, int dmg)
        {
            actor.HitPoints = actor.HitPoints - dmg;
        }

        public string GetClassDescription()
        {
            return "The mechanic looks around carefully. Dirt and oil seem to cover all areas of visable skin.";
        }

        public void RestoreHealth(IActor actor, int healing)
        {
            actor.HitPoints = actor.HitPoints + healing;
        }

        private void AdjustStamina(IActor actor, int adjustment)
        {
            actor.Stamina = actor.Stamina - adjustment;
        }
    }
}
