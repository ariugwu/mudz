namespace mudz.Core.Model.Domain
{
    public interface IGameObject
    {
        string Name { get; }
        
        double Dexterity { get; }
        double HitPoints { get; }

        GameObjectTypes GameObjectType { get;}

        bool IsDestructible { get; }

        void TakeDamage(double dmg);

        void Heal(double health);
    }
}
