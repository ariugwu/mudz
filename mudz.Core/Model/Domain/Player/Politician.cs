using System;

namespace mudz.Core.Model.Domain.Player
{
    public class Politician : IPlayerActionStrategy
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

        public double Attack()
        {
            throw new NotImplementedException();
        }

        public double Heal()
        {
            return -4;
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Inspect()
        {
            throw new NotImplementedException();
        }

        public void Repair()
        {
            throw new NotImplementedException();
        }

        public void Negotiate()
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(double dmg)
        {
            throw new NotImplementedException();
        }

        public void Heal(double health)
        {
            throw new NotImplementedException();
        }
    }
}
