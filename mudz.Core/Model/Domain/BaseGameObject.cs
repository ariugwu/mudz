namespace mudz.Core.Model.Domain
{
    public abstract class BaseGameObject : IGameObject
    {
        public string Name { get; set; }

        public double Dexterity { get; private set; }

        public double HitPoints { get; private set; }

        public GameObjectTypes GameObjectType { get; set; }

        public bool IsDestructible { get; private set; }

        public abstract void TakeDamage(double dmg);

        public abstract void Heal(double health);
    }
}
