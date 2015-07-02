using System;
using mudz.Common.Domain;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Inventory;

namespace mudz.Core.Model.Domain
{
    [Serializable]
    public abstract class BaseActor : BaseGameObject, IActor
    {
        #region Game Engine

        public int Stamina { get; set; }

        #endregion

        #region Actor Stats

        public abstract ActorGenderTypes Gender { get; set; }
        public ActorStates ActorState { get; set; }

        public int Health { get; set; }
        public int Strength { get; set; }
        public int Intellect { get; set; }
        public int Wisdom { get; set; }
        public int Agility { get; set; }
        public int Willpower { get; set; }
        public int Charm { get; set; }
        public int Endurance { get; set; }

        #endregion

        public override void CheckState()
        {
            CheckStamina();
            CheckAliveOrDead();
        }

        private void CheckAliveOrDead()
        {
            if (!IsAlive())
            {
                this.GameObjectState = GameObjectStates.OutOfPlay;
                this.ActorState = ActorStates.Dead;
            }
        }

        private void CheckStamina()
        {
            if (IsExhausted())
            {
                this.ActorState = ActorStates.Exhausted;
            }
        }

        private bool IsExhausted()
        {
            return this.Stamina <= 0;
        }

        private bool HasEnoughStaminaForAction(GameActions gameAction)
        {
            return this.Stamina >= GetStaminaCostByActionType(gameAction);
        }

        private bool IsAlive()
        {
            return this.HitPoints > 0;
        }

        private bool IsDisabled()
        {
            return ActorState == ActorStates.Disabled;
        }

        private ActionResult CannotRespond(ActionContext actionContext)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                Message = String.Format("{0} begins to move and then collapses!", this.Name),
            };
        }

        private ActionResult NotEnoughStamina(ActionContext actionContext)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                Message = String.Format("{0} does not have enough stamina (turns) to complete this action!", this.Name),
            };

        }

        public abstract int GetStaminaCostByActionType(GameActions gameAction);

        public override ActionResult ExecuteAction(ActionContext actionContext)
        {
            if (IsExhausted() || IsDisabled()) return CannotRespond(actionContext);
            if (!HasEnoughStaminaForAction(actionContext.CurrentAction)) return NotEnoughStamina(actionContext);

            var actionItem = new ActionResult();
            int amount = 0;

            switch (actionContext.CurrentAction)
            {
                case GameActions.Fight:
                    amount = this.Fight();
                    actionItem.WasSuccessful = true;
                    actionItem.Message = String.Format("{0} attacks for {1} damage!", this.Name, amount);
                    actionItem.Amount = amount;
                    return actionItem;
                case GameActions.Repair:
                    amount = this.Repair();
                    actionItem.Message = String.Format("{0} repairs for {1} hit points!", this.Name, amount);
                    actionItem.Amount = amount;
                    return actionItem;
                case GameActions.Negotiate:
                    amount = this.Negotiate();
                    actionItem.Message = String.Format("{0} negotiates for points!", this.Name, amount);
                    actionItem.Amount = amount;
                    return actionItem;
                case GameActions.Heal:
                    amount = this.Heal();
                    actionItem.Message = String.Format("{0} heals {1} for {2} damage!", actionContext.Player.Name, actionContext.Target.Name, amount);
                    actionItem.Amount = amount;
                    return actionItem;
                default:
                    throw new NotImplementedException("This action has not been implemented");
            }
        }

        public override ActionResult ProcessItem(ActionContext actionContext, IInventoryItem item)
        {
            AcceptItem(item);

            return new ActionResult()
            {
                WasSuccessful = true,
                Message = String.Format("{0} takes {1} and quickly hides it away.", this.Name, item.Name)
            };
        }

        public abstract void AcceptItem(IInventoryItem item);
    }
}
