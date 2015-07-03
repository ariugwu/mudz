﻿using System;
using mudz.Common.Domain;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Inventory;

namespace mudz.Core.Model.Domain
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
                return String.Format("You are looking at {0}. {1}. Health: {2}.", Name, GetDescription(), HitPoints);
            }
        }

        public int Dexterity { get; set; }

        public int HitPoints { get; set; }

        public GameObjectTypes GameObjectType { get; set; }

        public GameObjectStates GameObjectState { get; set; }

        public bool IsDestructible { get; private set; }

        public bool IsAttainable { get; set; }

        public abstract ActionResult RecieveGameActionResult(GameActions gameAction, ActionResult actionResult);

        public abstract ActionResult ExecuteAction(ActionContext actionContext);

        public abstract int CalculateGameAction(GameActions gameAction);

        public abstract void CheckState();

        public virtual string GetDescription()
        {
            return "There is nothing to see here.";
        }

        public virtual ActionResult ProcessItem(ActionContext actionContext, IInventoryItem item)
        {
            return new ActionResult()
            {
               WasSuccessful = false,
               Message = "Why would you want to do that?"
            };
        }
    }
}
