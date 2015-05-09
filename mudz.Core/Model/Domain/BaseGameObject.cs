using mudz.Core.Model.Domain.GameEngine;

namespace mudz.Core.Model.Domain
{
    public abstract class BaseGameObject : IGameObject
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Dexterity { get; set; }

        public int HitPoints { get; set; }

        public GameObjectTypes GameObjectType { get; set; }

        public GameObjectStates GameObjectState { get; set; }

        public bool IsDestructible { get; private set; }

        public bool IsAttainable { get; set; }

        public abstract int Fight();
        public abstract int Heal();
        public abstract int Repair();
        public abstract int Negotiate();

        public abstract void TakeDamage(int dmg);

        public abstract void RestoreHealth(int health);

        public abstract GameResponse Execute(GameRequest request);

        public abstract void CheckState();
    }
}
