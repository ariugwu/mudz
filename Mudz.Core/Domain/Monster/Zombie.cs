using System;
using Mudz.Common.Domain;
using Mudz.Common.Domain.Inventory;
using Mudz.Common.Domain.Monster;
using Mudz.Common.Domain.Player.Inventory;
using Mudz.Data.Domain;
using Mudz.Data.Domain.Player.Inventory;

namespace Mudz.Core.Domain.Monster
{
    [Serializable]
    public class Zombie : BaseMonster
    {
        public Zombie(string name, MonsterTypes monsterType)
        {
            Name = name;
            MonsterType = monsterType;
        }

        public Zombie() : this("Carl", MonsterTypes.Zombie) { }

        public override ActorGenderType Gender
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public override void AcceptItem(IInventoryItem item)
        {
            throw new System.NotImplementedException();
        }

        public override void EquipWeapon(IPlayerWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public override void EquipWearable(IPlayerWearable wearable)
        {
            throw new NotImplementedException();
        }

        public override string GetDescription()
        {
            return "The zombie is a husk which moves with some effort. While it appears easy to defeat its blood soaked hands and mouth give you pause.";
        }
    }
}
