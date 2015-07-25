namespace Mudz.Common.Domain.Player.Inventory
{
	public interface IPlayerWearable : IPlayerInventoryItem
    {
        PlayerAnatomy Anatomy { get; }
    }
}
