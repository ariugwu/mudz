
namespace mudz.Core.Model.Domain.Player
{
    public interface IPlayer
    {
        PlayerTypes PlayerType { get; set; }

        void Repair();

        void Attack();

        void Heal();

        void Negotiate();

        void Move();
    }
}
