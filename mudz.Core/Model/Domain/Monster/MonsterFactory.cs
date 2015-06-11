using System;
using mudz.Common.Domain;
using mudz.Common.Domain.Monster;

namespace mudz.Core.Model.Domain.Monster
{
    public static class MonsterFactory
    {
        public static IMonster Create(MonsterTypes monsterType)
        {
            var gameObjectKey = Guid.NewGuid();

            switch (monsterType)
            {
                case MonsterTypes.Zombie:
                    return new Zombie(){ HitPoints = 100, GameObjectKey = gameObjectKey, GameObjectState = GameObjectStates.InPlay};
                    break;
                default:
                    throw new NotImplementedException("Sorry this type is not supported!");
            }
        }
    }
}
