using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mudz.Core.Model.Domain.Player
{
    public class ArmyVet : Player
    {
        public ArmyVet()
        {

        }

        public ArmyVet(string name) : base(name)
        {
            PlayerType = PlayerTypes.ArmyVet;
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
