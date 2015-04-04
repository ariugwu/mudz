
namespace mudz.Core.Model.Domain.Player
{
    public interface IPlayer : IGameObject
    {
        PlayerTypes PlayerType { get; set; }

        int Experience { get; set; }

        int Level { get; set; }

        void Inspect();

        void Repair();

        void Attack();

        void Heal();

        void Negotiate();

        void Move();
    }
}
