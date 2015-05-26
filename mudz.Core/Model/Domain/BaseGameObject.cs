using System;
using mudz.Core.Model.Domain.GameEngine;
using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Model.Domain
{
    public abstract class BaseGameObject : IGameObject
    {
        public Guid GameObjectKey { get; set; }

        public string Name { get; set; }

        public string Description
        {
            get
            {
                return String.Format("You are looking at {0}. {1}. Health: {2}.", Name, GetDescription(), HitPoints);
            }
        }

        public int Dexterity { get; set; }

        public int HitPoints { get; set; }

        public GameObjectTypes GameObjectType { get; set; }

        public GameObjectStates GameObjectState { get; set; }

        public bool IsDestructible { get; private set; }

        public bool IsAttainable { get; set; }

        public abstract int Fight();
        public abstract int Heal();
        public abstract int Repair();
        public abstract int Negotiate();

        public abstract void TakeDamage(int dmg);

        public abstract void RestoreHealth(int health);

        public abstract GameResponse ExecuteAction(GameRequest request);

        public abstract void CheckState();

        public virtual string GetDescription()
        {
            return "There is nothing to see here.";
        }

        public virtual GameResponse ProcessItem(IInventoryItem item)
        {
            return new GameResponse()
            {
               Request = new GameRequest(),
               WasSuccessful = false,
               Message = "Why would you want to do that?"
            };
        }
    }
}
