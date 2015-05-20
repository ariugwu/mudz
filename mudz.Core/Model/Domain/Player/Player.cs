using System;
using System.Collections.Generic;
using System.Linq;
using mudz.Core.Model.Domain.GameEngine;
using mudz.Core.Model.Domain.Inventory;
using mudz.Core.Model.Domain.Player.Class;
using mudz.Core.Model.Domain.Player.Inventory;
using mudz.Core.Model.Domain.Player.Inventory.Item.Weapon;

namespace mudz.Core.Model.Domain.Player
{
    public sealed class Player : BaseActor, IPlayer
    {
        public Player(string name, ActorGenderTypes gender, PlayerTypes playerType, IPlayerActionStrategy actionStrategy)
        {
            Name = name;
            Gender = gender;
            PlayerType = playerType;
            GameObjectType = GameObjectTypes.Player;
            
            GameObjectState = GameObjectStates.InPlay;
            ActorState = ActorStates.Alive;

            _actionStrategy = actionStrategy;
            _actionStrategy.SetStats(this);

            // New up Inventory stores
            Inventory = new List<PlayerInventoryItem>();
            Outfit = new Dictionary<PlayerAnatomy, PlayerWearable>();
            Weapon = new Fists();
        }

        public Player() : this("", ActorGenderTypes.Wat, PlayerTypes.ArmyVet, new ArmyVet())
        {
            
        }

        private IPlayerActionStrategy _actionStrategy;

        public PlayerTypes PlayerType { get; set; }

        public override ActorGenderTypes Gender { get; set; }

        public int Experience { get; set; }

        public int Level { get; set; }

        public IList<PlayerInventoryItem> Inventory { get; private set; }

        public Dictionary<PlayerAnatomy, PlayerWearable> Outfit { get; private set; }

        public PlayerWeapon Weapon { get; set; }

        public void SetState(ActorStates actorState)
        {
            ActorState = actorState;
        }

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

        public string GetName()
        {
            return Name;
        }

        public override string GetDescription()
        {
            var physique = (this.Strength > 100) ? "Appears strongly built." : "Has a normal build";
            var desc = String.Format("{0}. {1}.", physique, _actionStrategy.GetClassDescription());
            return desc;
        }

        public override int GetStaminaCostByActionType(GameActions gameAction)
        {
            return _actionStrategy.ActionStaminaCostMap[gameAction];
        }

        public override int Fight()
        {
            var boost = CalculateActionBoostFromItems(InventoryAugmentEffect.Attack);

            return _actionStrategy.Attack(this) + boost;
        }

        public override int Heal()
        {
            var boost = CalculateActionBoostFromItems(InventoryAugmentEffect.Heal);

            return _actionStrategy.Heal(this) + boost;
        }

        public override int Repair()
        {
            var boost = CalculateActionBoostFromItems(InventoryAugmentEffect.Repair);

            return _actionStrategy.Repair(this) + boost;
        }

        public override int Negotiate()
        {
            var boost = CalculateActionBoostFromItems(InventoryAugmentEffect.Negotiate);

            return _actionStrategy.Negotiate(this) + boost;
        }

        public int CalculateActionBoostFromItems(InventoryAugmentEffect effect)
        {
            // Find the weapon boost
            var weaponBoost = (Weapon.ActionEffect.ContainsKey(effect)) ? Weapon.ActionEffect[effect] : 0;

            // Find the oufit boost
            var outfitItemsWithBoost = Outfit.Where(x => x.Value.ActionEffect.ContainsKey(effect));
            var outfitBoost = outfitItemsWithBoost.Sum(x => x.Value.ActionEffect[effect]);

            // Find the boost from keepsakes.
            var inventoryItemsWithBoost = Inventory.Where(x => x.ActionEffect.ContainsKey(effect) && x.InventoryType.Equals(InventoryTypes.PlayerKeepsake)).Sum(x => x.ActionEffect[effect]);

            return weaponBoost + outfitBoost + inventoryItemsWithBoost;
        }

        public override void TakeDamage(int dmg)
        {
            _actionStrategy.TakeDamage(this,dmg);
        }

        public override void RestoreHealth(int health)
        {
            _actionStrategy.RestoreHealth(this, health);
        }
    }
}
