using System;

namespace mudz.Core.Model.Domain.Monster
{
    public static class MonsterFactory
    {
        public static IMonster Create(MonsterTypes monsterType)
        {
            switch (monsterType)
            {
                case MonsterTypes.Zombie:
                    return new Zombie();
                    break;
                default:
                    throw new NotImplementedException("Sorry this type is not supported!");
            }
        }
    }
}
