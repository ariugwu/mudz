namespace mudz.Core.Model.Domain.Player
{
    public interface IPlayerActionStrategy
    {
        void SetStats(IActor actor);

        double Repair(IActor actor);
        double Negotiate(IActor actor);

        double Attack(IActor actor);
        double Heal(IActor actor);

        void RestoreHealth(IActor actor, double health);
        void TakeDamage(IActor actor, double dmg);

    }
}
