namespace mudz.Core.Model.Domain.Player
{
    public interface IPlayerActionStrategy
    {
        void SetStats(IPlayer player);

        void Move();

        void Inspect(IPlayer player);
        void Repair(IPlayer player);
        void Negotiate(IPlayer player);

        double Attack(IPlayer player);
        double Heal(IPlayer player);

        void Heal(IPlayer playerm, double health);
        void TakeDamage(IPlayer player, double dmg);

    }
}
