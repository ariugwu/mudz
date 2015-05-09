namespace mudz.Core.Model.Domain.Player.Class
{
    public class Carpenter : IPlayerActionStrategy
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

        public int Attack(IActor actor)
        {
            AdjustStamina(actor, 2);
            return 7;
        }

        public int Heal(IActor actor)
        {
            AdjustStamina(actor, 2);
            return 5;
        }

        public int Repair(IActor actor)
        {
            AdjustStamina(actor, 1);
            return 20;
        }

        public int Negotiate(IActor actor)
        {
            AdjustStamina(actor, 3);
            return 6;
        }

        public void TakeDamage(IActor actor, int dmg)
        {
            actor.HitPoints = actor.HitPoints - dmg;
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
