using System;

namespace mudz.Core.Model.Domain.Player
{
    public class Medic : Player
    {
        public Medic(string name)
        {
            Name = name;
            PlayerType = PlayerTypes.Medic;
        }

        public override void Repair()
        {
            throw new System.NotImplementedException();
        }

        public override void Attack()
        {
            throw new System.NotImplementedException();
        }

        public override void Heal()
        {
            throw new System.NotImplementedException();
        }

        public override void Negotiate()
        {
            throw new System.NotImplementedException();
        }

        public override void Move()
        {
            throw new System.NotImplementedException();
        }

        public override void TakeDamage(double dmg)
        {
            throw new NotImplementedException();
        }

        public override void Heal(double health)
        {
            throw new NotImplementedException();
        }
    }
}
