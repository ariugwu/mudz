namespace mudz.Core.Model.Domain.Player
{
    public interface IPlayerActionStrategy
    {
        
        void Move();
        void Inspect();
        void Repair();
        void Negotiate();

        double Attack();
        double Heal();

        void Heal(double health);
        void TakeDamage(double dmg);
    }
}
