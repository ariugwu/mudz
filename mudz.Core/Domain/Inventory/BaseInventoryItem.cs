using System;
using mudz.Common.Domain;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Inventory;

namespace mudz.Core.Model.Domain.Inventory
{
    [Serializable]
    public abstract class BaseInventoryItem : IInventoryItem
    {
        public Guid GameObjectKey { get; set; }

        public abstract InventoryTypes InventoryType { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Dexterity { get; set; }

        public int HitPoints { get; set; }

        public GameObjectTypes GameObjectType { get { return GameObjectTypes.InventoryItem; } }

        public GameObjectStates GameObjectState { get; set; }

        public abstract bool IsDestructible { get; }

        public abstract bool IsAttainable { get; }

        #region Default Actions

        public virtual int Fight()
        {
            return 0;
        }
        public virtual int Heal()
        {
            return 0;
        }

        public virtual int Negotiate()
        {
            return 0;
        }

        public virtual int Repair()
        {
            return 0;
        }

        #endregion

        public int CalculateGameAction(GameActions gameAction)
        {
            return 0;
        }

        public ActionResult RecieveGameActionResult(GameActions gameActions, ActionResult actionResult)
        {
            return new ActionResult()
            {
                Message = "Why would an item ever be apart of this?",
                WasSuccessful = false
            };
        }

        public virtual ActionResult ExecuteAction(ActionContext actionContext)
        {

            switch (actionContext.CurrentAction)
            {
                case GameActions.Heal:
                    return new ActionResult(){ WasSuccessful = false, Message = "Items can't be healed!"};
                case GameActions.Negotiate:
                    return new ActionResult() { WasSuccessful = false, Message = "You'd have better luck convincing yourself!" };
                case GameActions.Repair:
                    return new ActionResult() { WasSuccessful = false, Message = "How would that work exactly?" };
                case GameActions.Fight:
                    return new ActionResult() { WasSuccessful = false, Message = "So like...a heavy bag? Or..." };
                default:
                    throw new NotImplementedException("Game action not supported!");
            }
        }

        public virtual ActionResult ProcessItem(ActionContext actionContext, IInventoryItem item)
        {
            return new ActionResult() { WasSuccessful = false, Message = "Why would you want to do that?" };
        }

        public virtual void CheckState()
        {
            // There is no base functionality for this method. Marked as virtual to prevent needless overrides.
        }
    }
}
