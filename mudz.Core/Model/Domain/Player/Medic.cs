namespace mudz.Core.Model.Domain.Player
{
    public class Medic : IPlayerActionStrategy
    {
        public void SetStats(IPlayer player)
        {
            player.Health = 185;
            player.Strength = 145;
            player.Intellect = 80;
            player.Wisdom = 65;
            player.Agility = 145;
            player.Willpower = 150;
            player.Charm = 40;
            player.Endurance = 165;
        }

        public double Attack(IPlayer player)
        {
            AdjustStamina(player, 3);
            return 5;
        }

        public double Heal(IPlayer player)
        {
            AdjustStamina(player, 1);
            return 20;
        }

        public double Repair(IPlayer player)
        {
            AdjustStamina(player, 2);
            return 6;
        }

        public double Negotiate(IPlayer player)
        {
            AdjustStamina(player, 2);
            return 10;
        }

        public void TakeDamage(IPlayer player, double dmg)
        {
            player.HitPoints = player.HitPoints - dmg;
        }

        public void RestoreHealth(IPlayer player, double healing)
        {
            player.HitPoints = player.HitPoints + healing;
        }

        private void AdjustStamina(IPlayer player, int adjustment)
        {
            player.Stamina = player.Stamina - adjustment;
        }
    }
}
