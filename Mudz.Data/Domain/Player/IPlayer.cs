using Mudz.Data.Domain.Player.Inventory;

namespace Mudz.Data.Domain.Player
{
    public interface IPlayer: IGameObject
    {
        PlayerTypes PlayerType { get; set; }
        
        int Stamina { get; set; }

        string GetName();

        string GetDescription();

        void AddInventoryItem(IPlayerInventoryItem item);

        void RemoveInventoryItem(int index);

        void EquipWeapon(IPlayerWeapon weapon);

        void EquipWearable(IPlayerWearable wearable);

        void SetState(ActorStates actorState);

    }
}
