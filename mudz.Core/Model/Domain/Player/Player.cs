using System.Collections.Generic;
using System.Linq;
using mudz.Core.Model.Domain.Inventory;
using mudz.Core.Model.Domain.Player.Inventory;
using mudz.Core.Model.Domain.Player.Inventory.Item.Weapon;

namespace mudz.Core.Model.Domain.Player
{
    public class Player : BaseActor, IPlayer
    {
        public Player(string name, PlayerTypes playerType, IPlayerActionStrategy actionStrategy)
        {
            Name = name;
            PlayerType = playerType;
            GameObjectType = GameObjectTypes.Player;
            _actionStrategy = actionStrategy;
            _actionStrategy.SetStats(this);

            // New up Inventory stores
            Inventory = new List<PlayerInventoryItem>();
            Outfit = new Dictionary<PlayerAnatomy, PlayerWearable>();
            Weapon = new Fists();
        }

        public Player() : this("", PlayerTypes.ArmyVet, new ArmyVet())
        {
            
        }

        private IPlayerActionStrategy _actionStrategy;

        public PlayerTypes PlayerType { get; set; }

        public int Experience { get; set; }

        public int Level { get; set; }

        public IList<PlayerInventoryItem> Inventory { get; private set; }

        public Dictionary<PlayerAnatomy, PlayerWearable> Outfit { get; private set; }

        public PlayerWeapon Weapon { get; set; }

        public void AddInventoryItem(PlayerInventoryItem item)
        {
            Inventory.Add(item);
        }

        public void RemoveInventoryItem(int index)
        {
            Inventory.RemoveAt(index);
        }

        public void EquipWeapon(PlayerWeapon weapon)
        {
            Weapon = weapon;
        }

        public void EquipWearable(PlayerWearable wearable)
        {
            Outfit[wearable.Anatomy] = wearable;
        }

        public override double Fight()
        {
            // Find the weapon boost
            var weaponBoost = (Weapon.HasAttackBoost) ? Weapon.CalcAttackBoost : 0;

            // Find the oufit boost
            var outfitItemsWithBoost = Outfit.Where(x => x.Value.HasAttackBoost);
            var outfitBoost = outfitItemsWithBoost.Sum(x => x.Value.CalcAttackBoost);

            // Find the boost from keepsakes.
            var inventoryItemsWithBoost = Inventory.Where(x => x.HasAttackBoost && x.InventoryType == InventoryTypes.PlayerKeepsake).Sum(x => x.CalcAttackBoost);

            return _actionStrategy.Attack(this) + weaponBoost + outfitBoost + inventoryItemsWithBoost;
        }

        public override double Heal()
        {
            // Find the weapon boost
            var weaponBoost = (Weapon.HasHealBoost) ? Weapon.CalcHealBoost : 0;

            // Find the oufit boost
            var outfitItemsWithBoost = Outfit.Where(x => x.Value.HasHealBoost);
            var outfitBoost = outfitItemsWithBoost.Sum(x => x.Value.CalcHealBoost);

            // Find the boost from keepsakes.
            var inventoryItemsWithBoost = Inventory.Where(x => x.HasHealBoost && x.InventoryType == InventoryTypes.PlayerKeepsake).Sum(x => x.CalcHealBoost);

            return _actionStrategy.Heal(this) + weaponBoost + outfitBoost + inventoryItemsWithBoost;
        }

        public double Repair()
        {
            // Find the weapon boost
            var weaponBoost = (Weapon.HasRepairBoost) ? Weapon.CalcRepairBoost : 0;

            // Find the oufit boost
            var outfitItemsWithBoost = Outfit.Where(x => x.Value.HasRepairBoost);
            var outfitBoost = outfitItemsWithBoost.Sum(x => x.Value.CalcRepairBoost);

            // Find the boost from keepsakes.
            var inventoryItemsWithBoost = Inventory.Where(x => x.HasRepairBoost && x.InventoryType == InventoryTypes.PlayerKeepsake).Sum(x => x.CalcRepairBoost);

            return _actionStrategy.Repair(this) + weaponBoost + outfitBoost + inventoryItemsWithBoost;
        }

        public double Negotiate()
        {
            // Find the weapon boost
            var weaponBoost = (Weapon.HasNegotiateBoost) ? Weapon.CalcNegotiateBoost : 0;

            // Find the oufit boost
            var outfitItemsWithBoost = Outfit.Where(x => x.Value.HasNegotiateBoost);
            var outfitBoost = outfitItemsWithBoost.Sum(x => x.Value.CalcNegotiateBoost);

            // Find the boost from keepsakes.
            var inventoryItemsWithBoost = Inventory.Where(x => x.HasNegotiateBoost && x.InventoryType == InventoryTypes.PlayerKeepsake).Sum(x => x.CalcNegotiateBoost);

            return _actionStrategy.Negotiate(this) + weaponBoost + outfitBoost + inventoryItemsWithBoost;;
        }

        public override void TakeDamage(double dmg)
        {
            _actionStrategy.TakeDamage(this,dmg);
        }

        public override void RestoreHealth(double health)
        {
            _actionStrategy.RestoreHealth(this, health);
        }
    }
}
