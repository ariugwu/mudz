using System;

namespace mudz.Core.Model.Domain.Player
{
    public class Carpenter : Player
    {
        public Carpenter(string name) : base(name)
        {
            PlayerType = PlayerTypes.Carpenter;
        }

        public override void Repair()
        {
            throw new NotImplementedException();
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Heal()
        {
            throw new NotImplementedException();
        }

        public override void Negotiate()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
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
