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
    }
}
