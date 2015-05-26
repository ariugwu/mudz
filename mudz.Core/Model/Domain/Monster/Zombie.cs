using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Model.Domain.Monster
{
    public class Zombie : BaseMonster
    {
        public Zombie(string name, MonsterTypes monsterType)
        {
            Name = name;
            MonsterType = monsterType;
        }

        public Zombie() : this("Carl",MonsterTypes.Zombie) { }

        public override ActorGenderTypes Gender
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public override void AcceptItem(IInventoryItem item)
        {
            throw new System.NotImplementedException();
        }

        public override string GetDescription()
        {
            return "The zombie is a husk which moves with some effort. While it appears easy to defeat its blood soaked hands and mouth give you pause.";
        }
    }
}
