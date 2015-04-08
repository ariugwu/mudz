namespace mudz.Core.Model.Domain.Player
{
    public interface IPlayerActionStrategy
    {
        void Attack();
        void Move();
        void Inspect();
        void Repair();
        void Negotiate();
        void TakeDamage(double dmg);
        void Heal(double health);
    }
}
