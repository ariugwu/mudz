using System;
using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Inventory;
using Mudz.Data.Domain.GameEngine;

namespace Mudz.Core.Domain.Inventory
{
    [Serializable]
    public abstract class BaseInventoryItem : IInventoryItem
    {

        protected BaseInventoryItem()
        {
            GameObjectKey = Guid.NewGuid();
        }

        public Guid GameObjectKey { get; set; }

        public abstract InventoryType InventoryType { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Dexterity { get; set; }

        public int HitPoints { get; set; }

        public GameObjectType GameObjectType { get { return GameObjectType.InventoryItem; } }

        public GameObjectState GameObjectState { get; set; }

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

        public int CalculateGameAction(GameAction gameAction)
        {
            return 0;
        }

        public IActionResult RecieveGameActionResult(GameAction gameAction, IActionResult actionResult, string playerName)
        {
            return new ActionResult()
            {
                PlayerMessage = "Why would an item ever be apart of this?",
                WasSuccessful = false
            };
        }

        public virtual IActionResult ExecuteAction(IActionContext actionContext)
        {

            switch (actionContext.GameRequest.GameAction)
            {
                case GameAction.Heal:
                    return new ActionResult() { WasSuccessful = false, PlayerMessage = "Items can't be healed!" };
                case GameAction.Negotiate:
                    return new ActionResult() { WasSuccessful = false, PlayerMessage = "You'd have better luck convincing yourself!" };
                case GameAction.Repair:
                    return new ActionResult() { WasSuccessful = false, PlayerMessage = "How would that work exactly?" };
                case GameAction.Fight:
                    return new ActionResult() { WasSuccessful = false, PlayerMessage = "So like...a heavy bag? Or..." };
                default:
                    throw new NotImplementedException("Game action not supported!");
            }
        }

        public virtual IActionResult ProcessItem(IActionContext actionContext, IInventoryItem item)
        {
            return new ActionResult() { WasSuccessful = false, PlayerMessage = "Why would you want to do that?" };
        }

        public virtual void CheckState()
        {
            // There is no base functionality for this method. Marked as virtual to prevent needless overrides.
        }
    }
}
