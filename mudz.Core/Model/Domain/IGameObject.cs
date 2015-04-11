namespace mudz.Core.Model.Domain
{
    public interface IGameObject
    {
        string Name { get; }
        string Description { get; set; }

        double Dexterity { get; }
        double HitPoints { get; set; }

        GameObjectTypes GameObjectType { get;}

        bool IsDestructible { get; }

        void TakeDamage(double dmg);

        void RestoreHealth(double health);
    }
}
