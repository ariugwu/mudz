namespace mudz.Core.Model.Domain.Player
{
    public interface IPlayerActionStrategy
    {
        void SetStats(IPlayer player);

        double Repair(IPlayer player);
        double Negotiate(IPlayer player);

        double Attack(IPlayer player);
        double Heal(IPlayer player);

        void RestoreHealth(IPlayer player, double health);
        void TakeDamage(IPlayer player, double dmg);

    }
}
