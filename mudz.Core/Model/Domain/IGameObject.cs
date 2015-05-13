using System;
using mudz.Core.Model.Domain.GameEngine;

namespace mudz.Core.Model.Domain
{
    public interface IGameObject : IGameCommand
    {
        Guid GameObjectKey { get; set; }

        string Name { get; }
        string Description { get; }

        int Dexterity { get; }
        int HitPoints { get; set; }

        GameObjectTypes GameObjectType { get;}
        GameObjectStates GameObjectState { get; set; }

        bool IsDestructible { get; }
        bool IsAttainable { get; }

        int Fight();
        int Heal();
        int Repair();
        int Negotiate();

        void TakeDamage(int dmg);
        void RestoreHealth(int health);

    }
}
