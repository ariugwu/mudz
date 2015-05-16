namespace mudz.Core.Model.Domain.Player
{
    public interface IPlayerActionStrategy
    {
        void SetStats(IActor actor);

        int Repair(IActor actor);
        int Negotiate(IActor actor);

        int Attack(IActor actor);
        int Heal(IActor actor);

        void RestoreHealth(IActor actor, int health);
        void TakeDamage(IActor actor, int dmg);

        string GetClassDescription();

    }
}
