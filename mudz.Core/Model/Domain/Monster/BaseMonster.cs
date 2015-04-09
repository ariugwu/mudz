using System.Collections.Generic;
using mudz.Core.Model.Domain.InventoryItem;

namespace mudz.Core.Model.Domain.Monster
{
    public abstract class BaseMonster : BaseActor, IMonster
    {

        public MonsterTypes MonsterType { get; set; }

        public override void TakeDamage(double dmg)
        {
            throw new System.NotImplementedException();
        }

        public override void RestoreHealth(double health)
        {
            throw new System.NotImplementedException();
        }

        public override double Attack()
        {
            return 33;
        }

        public override double Heal()
        {
            return 0;
        }

        public override void Move()
        {
            throw new System.NotImplementedException();
        }

        public BaseActor Statistics
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public IList<IInventoryItem> Inventory
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public bool HasItem
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public double DropRate
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }
    }
}
