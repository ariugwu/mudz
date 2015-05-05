using mudz.Core.Model.Domain.GameEngine;

namespace mudz.Core.Model.Domain
{
    public abstract class BaseGameObject : IGameObject
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Dexterity { get; set; }

        public double HitPoints { get; set; }

        public GameObjectTypes GameObjectType { get; set; }

        public GameObjectStates GameObjectState { get; set; }

        public bool IsDestructible { get; private set; }

        public bool IsAttainable { get; set; }

        public abstract double Fight();
        public abstract double Heal();
        public abstract double Repair();
        public abstract double Negotiate();

        public abstract void TakeDamage(double dmg);

        public abstract void RestoreHealth(double health);

        public abstract GameResponse Execute(GameRequest request);
    }
}
