namespace mudz.Core.Model.Domain.Player.Class
{
    public class Politician : IPlayerActionStrategy
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
            AdjustStamina(actor, 3);
            return 4;
        }

        public int Heal(IActor actor)
        {
            AdjustStamina(actor, 3);
            return -4;
        }

        public int Repair(IActor actor)
        {
            AdjustStamina(actor, 3);
            return 10;
        }

        public int Negotiate(IActor actor)
        {
            AdjustStamina(actor, 1);
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
