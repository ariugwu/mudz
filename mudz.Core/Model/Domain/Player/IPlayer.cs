using mudz.Core.Model.Domain.Player.Inventory;

namespace mudz.Core.Model.Domain.Player
{
    public interface IPlayer: IGameObject
    {
        PlayerTypes PlayerType { get; set; }

        string GetName();

        string GetDescription();

        double Fight();

        double Heal();

        double Repair();

        double Negotiate();

        void AddInventoryItem(PlayerInventoryItem item);

        void RemoveInventoryItem(int index);

        void EquipWeapon(PlayerWeapon weapon);

        void EquipWearable(PlayerWearable wearable);

    }
}
