using mudz.Core.Model.Domain.GameEngine;

namespace mudz.Core.Model.Domain
{
    public interface IGameObject : IGameCommand
    {
        string Name { get; }
        string Description { get; set; }

        double Dexterity { get; }
        double HitPoints { get; set; }

        GameObjectTypes GameObjectType { get;}

        bool IsDestructible { get; }
        bool IsAttainable { get; }

        double Fight();
        double Heal();
        double Repair();
        double Negotiate();

        void TakeDamage(double dmg);
        void RestoreHealth(double health);
    }
}
