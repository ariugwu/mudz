using mudz.Common.Domain.Inventory;

namespace mudz.Common.Domain.Player.Inventory
{
    public interface IPlayerWearable : IPlayerInventoryItem
    {
        PlayerAnatomy Anatomy { get; }
    }
}
