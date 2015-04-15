using System;
using System.Collections.Generic;
using mudz.Core.Model.Domain.Player.Inventory;

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
        }

        public Player() : this("", PlayerTypes.ArmyVet, new ArmyVet())
        {
            
        }

        private IPlayerActionStrategy _actionStrategy;

        public PlayerTypes PlayerType { get; set; }

        public int Experience { get; set; }

        public int Level { get; set; }

        public IList<PlayerInventoryItem> Inventory { get; private set; }

        public void AddInventoryItem(PlayerInventoryItem item)
        {
            Inventory.Add(item);
        }

        public void RemoveInventoryItem(int index)
        {
            Inventory.RemoveAt(index);
        }

        public override double Fight()
        {
            return _actionStrategy.Attack(this);
        }

        public override double Heal()
        {
            return _actionStrategy.Heal(this);
        }

        public void Repair()
        {
            _actionStrategy.Repair(this);
        }

        public void Negotiate()
        {
            _actionStrategy.Negotiate(this);
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
