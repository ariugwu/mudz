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
    public class ArmyVet : IPlayerActionStrategy
    {
        private Dictionary<GameAction, int> _actionStaminaCostMap = new Dictionary<GameAction, int>()
        {
            {GameAction.Fight, 1},
            {GameAction.Heal, 3},
            {GameAction.Repair, 3},
            {GameAction.Negotiate, 3}
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
            return 20;
        }

        public int Heal(IActor actor)
        {
            AdjustStamina(actor, ActionStaminaCostMap[GameAction.Heal]);
            return 10;
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
            return "Army Vets are known for being tough. A wide array of tools and weapons can be seen attached to various belts and loops.";
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
