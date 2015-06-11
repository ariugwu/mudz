using System;
using System.Collections.Generic;
using mudz.Common.Domain;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Player;

namespace mudz.Core.Model.Domain.Player.Class
{
    [Serializable]
    public class ArmyVet : IPlayerActionStrategy
    {
        private Dictionary<GameActions, int> _actionStaminaCostMap = new Dictionary<GameActions, int>()
        {
            {GameActions.Fight, 1},
            {GameActions.Heal, 3},
            {GameActions.Repair, 3},
            {GameActions.Negotiate, 3}
        };

        public Dictionary<GameActions, int> ActionStaminaCostMap
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
            AdjustStamina(actor, ActionStaminaCostMap[GameActions.Fight]);
            return 20;
        }

        public int Heal(IActor actor)
        {
            AdjustStamina(actor, ActionStaminaCostMap[GameActions.Heal]);
            return 10;
        }

        public int Repair(IActor actor)
        {
            AdjustStamina(actor, ActionStaminaCostMap[GameActions.Repair]);
            return 10;
        }

        public int Negotiate(IActor actor)
        {
            AdjustStamina(actor, ActionStaminaCostMap[GameActions.Negotiate]);
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
