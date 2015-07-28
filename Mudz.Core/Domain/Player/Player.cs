using System;
using System.Collections.Generic;
using System.Linq;
using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Inventory;
using Mudz.Common.Domain.Player;
using Mudz.Common.Domain.Player.Inventory;
using Mudz.Core.Domain.Player.Inventory.Item.Weapon;
using Mudz.Core.Model.Domain.Player.Class;
using Mudz.Data.Domain.Player.Inventory;

namespace Mudz.Core.Domain.Player
{
    [Serializable]
    public sealed class Player : BaseActor, IPlayer
    {
        public Player(string name, ActorGenderType gender, PlayerTypes playerType, IPlayerActionStrategy actionStrategy)
        {
            Name = name;
            Gender = gender;
            PlayerType = playerType;
            GameObjectType = GameObjectType.Player;

            GameObjectState = GameObjectState.OutOfPlay;
            ActorState = ActorState.Alive;

            _actionStrategy = actionStrategy;
            _actionStrategy.SetStats(this);

            // New up Inventory stores
            Inventory = new List<IPlayerInventoryItem>();
            Outfit = new Dictionary<PlayerAnatomy, IPlayerWearable>();
            Weapon = new Fists();
        }

        public Player()
            : this("", ActorGenderType.Wat, PlayerTypes.ArmyVet, new ArmyVet())
        {

        }

        private IPlayerActionStrategy _actionStrategy;

        public PlayerTypes PlayerType { get; set; }

        public override ActorGenderType Gender { get; set; }

        public int Experience { get; set; }

        public int Level { get; set; }

        public IList<IPlayerInventoryItem> Inventory { get; private set; }

        public Dictionary<PlayerAnatomy, IPlayerWearable> Outfit { get; private set; }

        public IPlayerWeapon Weapon { get; set; }

        public void SetState(ActorState actorState)
        {
            ActorState = actorState;
        }

        public void AddInventoryItem(IPlayerInventoryItem item)
        {
            Inventory.Add(item);
        }

        public override void AcceptItem(IInventoryItem item)
        {
            AddInventoryItem((IPlayerInventoryItem)item);
        }

        public void RemoveInventoryItem(int index)
        {
            Inventory.RemoveAt(index);
        }

        public override void EquipWeapon(IPlayerWeapon weapon)
        {
            Weapon = weapon;
        }

        public override void EquipWearable(IPlayerWearable wearable)
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
            var desc = string.Format("{0}. {1}.", physique, _actionStrategy.GetClassDescription());
            return desc;
        }

        public override int GetStaminaCostByActionType(GameAction gameAction)
        {
            return _actionStrategy.ActionStaminaCostMap[gameAction];
        }


        public override int CalculateGameAction(GameAction gameAction)
        {
            switch (gameAction)
            {
                case GameAction.Fight:
                    return _actionStrategy.Attack(this) + CalculateActionBoostFromItems(InventoryAugmentEffect.Attack);
                case GameAction.Heal:
                    return _actionStrategy.Heal(this) + CalculateActionBoostFromItems(InventoryAugmentEffect.Heal);
                case GameAction.Repair:
                    return _actionStrategy.Repair(this) + CalculateActionBoostFromItems(InventoryAugmentEffect.Repair);
                case GameAction.Negotiate:
                    return _actionStrategy.Negotiate(this) + CalculateActionBoostFromItems(InventoryAugmentEffect.Negotiate);
                default:
                    throw new NotSupportedException("The action requested is not supported.");
            }
        }

        public int CalculateActionBoostFromItems(InventoryAugmentEffect effect)
        {
            // Find the weapon boost
            var weaponBoost = (Weapon.ActionEffect.ContainsKey(effect)) ? Weapon.ActionEffect[effect] : 0;

            // Find the oufit boost
            var outfitItemsWithBoost = Outfit.Where(x => x.Value.ActionEffect.ContainsKey(effect));
            var outfitBoost = outfitItemsWithBoost.Sum(x => x.Value.ActionEffect[effect]);

            // Find the boost from keepsakes.
            var inventoryItemsWithBoost = Inventory.Where(x => x.ActionEffect.ContainsKey(effect) && x.InventoryType.Equals(InventoryType.PlayerKeepsake)).Sum(x => x.ActionEffect[effect]);

            return weaponBoost + outfitBoost + inventoryItemsWithBoost;
        }

        public override void TakeDamage(int dmg)
        {
            _actionStrategy.TakeDamage(this, dmg);
        }

        public override void RestoreHealth(int health)
        {
            _actionStrategy.RestoreHealth(this, health);
        }
    }
}
