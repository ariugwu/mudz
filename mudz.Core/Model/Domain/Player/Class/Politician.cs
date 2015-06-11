using System;
using System.Collections.Generic;
using mudz.Common.Domain;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Player;

namespace mudz.Core.Model.Domain.Player.Class
{
    [Serializable]
    public class Politician : IPlayerActionStrategy
    {
        private Dictionary<GameActions, int> _actionStaminaCostMap = new Dictionary<GameActions, int>()
        {
            {GameActions.Fight, 3},
            {GameActions.Heal, 3},
            {GameActions.Repair, 3},
            {GameActions.Negotiate, 1}
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
            return 4;
        }

        public int Heal(IActor actor)
        {
            AdjustStamina(actor, ActionStaminaCostMap[GameActions.Heal]);
            return -4;
        }

        public int Repair(IActor actor)
        {
            AdjustStamina(actor, ActionStaminaCostMap[GameActions.Repair]);
            return 10;
        }

        public int Negotiate(IActor actor)
        {
            AdjustStamina(actor, ActionStaminaCostMap[GameActions.Negotiate]);
            return 20;
        }

        public void TakeDamage(IActor actor, int dmg)
        {
            actor.HitPoints = actor.HitPoints - dmg;
        }

        public string GetClassDescription()
        {
            return "The politician insists on wearing clean and pressed clothes. Standing out against the dead, dying, and destroyed background.";
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
