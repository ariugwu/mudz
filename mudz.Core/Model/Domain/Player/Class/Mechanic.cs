using System.Collections.Generic;
using mudz.Core.Model.Domain.GameEngine;

namespace mudz.Core.Model.Domain.Player.Class
{
    public class Mechanic : IPlayerActionStrategy
    {
        private Dictionary<GameActions, int> _actionStaminaCostMap = new Dictionary<GameActions, int>()
        {
            {GameActions.Fight, 2},
            {GameActions.Heal, 3},
            {GameActions.Repair, 1},
            {GameActions.Negotiate, 2}
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
            return 7;
        }

        public int Heal(IActor actor)
        {
            AdjustStamina(actor, ActionStaminaCostMap[GameActions.Heal]);
            return 5;
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
