using System;
using Mudz.Common.Domain;
using Mudz.Common.Domain.Monster;
using Mudz.Data.Domain;

namespace Mudz.Core.Domain.Monster
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
                default:
                    throw new NotImplementedException("Sorry this type is not supported!");
            }
        }
    }
}
