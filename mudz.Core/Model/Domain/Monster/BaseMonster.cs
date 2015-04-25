using System.Collections.Generic;
using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Model.Domain.Monster
{
    public abstract class BaseMonster : BaseActor, IMonster
    {
        protected BaseMonster()
        {
            GameObjectType = GameObjectTypes.Monster;
        }

        private double _dropRate = 0.10;

        public MonsterTypes MonsterType { get; set; }

        public override void TakeDamage(double dmg)
        {
            HitPoints = HitPoints - dmg;
        }

        public override void RestoreHealth(double health)
        {
            HitPoints = HitPoints + health;
        }

        public override double Fight()
        {
            return 33;
        }

        public override double Heal()
        {
            return 0;
        }

        public override double Negotiate()
        {
            return 0;
        }

        public override double Repair()
        {
            return 0;
        }

        public IList<IInventoryItem> Inventory
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        IList<IInventoryItem> IMonster.Inventory
        {
            get { return Inventory; }
            set { Inventory = value; }
        }

        public bool HasItem(IInventoryItem item)
        {
            throw new System.NotImplementedException();
        }

        public double DropRate
        {
            get { return _dropRate; }
            set { _dropRate = value; }
        }

    }
}
