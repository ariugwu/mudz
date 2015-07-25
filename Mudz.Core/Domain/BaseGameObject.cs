using System;
using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Inventory;
using Mudz.Data.Domain.GameEngine;

namespace Mudz.Core.Domain
{
    [Serializable]
    public abstract class BaseGameObject : IGameObject
    {
        public Guid GameObjectKey { get; set; }

        public string Name { get; set; }

        public string Description
        {
            get
            {
                return string.Format("You are looking at {0}. {1}. Health: {2}.", Name, GetDescription(), HitPoints);
            }
        }

        public int Dexterity { get; set; }

        public int HitPoints { get; set; }

        public GameObjectType GameObjectType { get; set; }

        public GameObjectState GameObjectState { get; set; }

        public bool IsDestructible { get; private set; }

        public bool IsAttainable { get; set; }

        public abstract IActionResult RecieveGameActionResult(GameAction gameAction, IActionResult actionResult, string playerName);

        public abstract IActionResult ExecuteAction(IActionContext actionContext);

        public abstract int CalculateGameAction(GameAction gameAction);

        public abstract void CheckState();

        public virtual string GetDescription()
        {
            return "There is nothing to see here.";
        }

        public virtual IActionResult ProcessItem(IActionContext actionContext, IInventoryItem item)
        {
            return new ActionResult()
            {
               WasSuccessful = false,
               PlayerMessage = "Why would you want to do that?"
            };
        }
    }
}
