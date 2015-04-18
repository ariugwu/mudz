namespace mudz.Core.Model.Domain.Player.Class
{
    public class Medic : IPlayerActionStrategy
    {
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

        public double Attack(IActor actor)
        {
            AdjustStamina(actor, 3);
            return 5;
        }

        public double Heal(IActor actor)
        {
            AdjustStamina(actor, 1);
            return 20;
        }

        public double Repair(IActor actor)
        {
            AdjustStamina(actor, 2);
            return 6;
        }

        public double Negotiate(IActor actor)
        {
            AdjustStamina(actor, 2);
            return 10;
        }

        public void TakeDamage(IActor actor, double dmg)
        {
            actor.HitPoints = actor.HitPoints - dmg;
        }

        public void RestoreHealth(IActor actor, double healing)
        {
            actor.HitPoints = actor.HitPoints + healing;
        }

        private void AdjustStamina(IActor actor, int adjustment)
        {
            actor.Stamina = actor.Stamina - adjustment;
        }
    }
}
