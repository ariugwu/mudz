
namespace mudz.Core.Model.Domain.Player
{
    public interface IPlayer : IActor
    {
        PlayerTypes PlayerType { get; set; }

        int Experience { get; set; }

        int Level { get; set; }

        void Repair();

        void Negotiate();

    }
}
