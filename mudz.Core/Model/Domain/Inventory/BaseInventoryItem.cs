using System;
using mudz.Core.Model.Domain.GameEngine;

namespace mudz.Core.Model.Domain.Inventory
{
    public abstract class BaseInventoryItem : IInventoryItem
    {
        public abstract InventoryTypes InventoryType { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Dexterity { get; set; }

        public double HitPoints { get; set; }

        public GameObjectTypes GameObjectType { get { return GameObjectTypes.InventoryItem; } }

        public GameObjectStates GameObjectState { get; set; }

        public abstract bool IsDestructible { get; }

        public abstract bool IsAttainable { get; }

        #region Default Actions

        public virtual double Fight()
        {
            return 0;
        }
        public virtual double Heal()
        {
            return 0;
        }

        public virtual double Negotiate()
        {
            return 0;
        }

        public virtual double Repair()
        {
            return 0;
        }

        #endregion

        public void TakeDamage(double dmg)
        {

        }

        public void RestoreHealth(double health)
        {

        }

        public virtual GameResponse Execute(GameRequest request)
        {
            var actionType = request.GameAction;

            switch (actionType)
            {
                case GameActions.Heal:
                    return new GameResponse(){ Message = "Items can't be healed!"};
                case GameActions.Negotiate:
                    return new GameResponse(){ Message = "You'd have better luck convincing yourself!"};
                case GameActions.Repair:
                    return new GameResponse(){ Message = "How would that work exactly?"};
                case GameActions.Fight:
                    return new GameResponse(){ Message = "So like...a heavy bag? Or..."};
                default:
                    throw new NotImplementedException("Game action not supported!");
            }
        }
    }
}
