namespace Mudz.Data.Domain.Player.Inventory
{
	public interface IPlayerWearable : IPlayerInventoryItem
    {
        PlayerAnatomy Anatomy { get; }
    }
}
