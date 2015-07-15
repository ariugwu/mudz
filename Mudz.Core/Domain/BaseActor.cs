using System;
using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Inventory;
using Mudz.Common.Domain.Localization;
using Mudz.Data.Domain.Localization;

namespace Mudz.Core.Domain
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

        public bool IsAlive()
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
                RoomMessage = String.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.CannotRespondRoomMessage], this.Name),
                PlayerMessage = TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.CannotRespondPlayerMessage]
            };
        }

        private ActionResult NotEnoughStamina(ActionContext actionContext)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                RoomMessage = String.Format("{0} does not have enough stamina (turns) to complete this action!", this.Name),
                PlayerMessage = "You do not have enough stamia (turns) to complete this action!"
            };

        }

        public abstract int GetStaminaCostByActionType(GameActions gameAction);

        public override ActionResult ExecuteAction(ActionContext actionContext)
        {
            if (IsExhausted() || IsDisabled()) return CannotRespond(actionContext);
            if (!HasEnoughStaminaForAction(actionContext.GameRequest.GameAction)) return NotEnoughStamina(actionContext);

            var actionResult = new ActionResult();
            int amount = 0;

            switch (actionContext.GameRequest.GameAction)
            {
                case GameActions.Fight:
                    amount = this.CalculateGameAction(actionContext.GameRequest.GameAction);
                    actionResult.WasSuccessful = true;
                    actionResult.RoomMessage = String.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.FightRoomMessage], this.Name, actionContext.Target.Name, amount);
                    actionResult.PlayerMessage = String.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.FightPlayerMessage], actionContext.Target.Name, amount);
                    actionResult.Amount = amount;
                    return actionResult;
                case GameActions.Repair:
                    amount = this.CalculateGameAction(actionContext.GameRequest.GameAction);
                    actionResult.RoomMessage = String.Format("{0} repairs {1} for {2} hit points!", this.Name, actionContext.Target.Name, amount);
                    actionResult.PlayerMessage = String.Format("You repair {0} for {1} hit points!", actionContext.Target.Name, amount);
                    actionResult.Amount = amount;
                    return actionResult;
                case GameActions.Negotiate:
                    amount = this.CalculateGameAction(actionContext.GameRequest.GameAction);
                    actionResult.RoomMessage = String.Format("{0} negotiates with {1} for {2} points!", this.Name, actionContext.Target.Name, amount);
                    actionResult.PlayerMessage = String.Format("You negotiate with {0} for {1} points!", actionContext.Target.Name, amount);
                    actionResult.Amount = amount;
                    return actionResult;
                case GameActions.Heal:
                    amount = this.CalculateGameAction(actionContext.GameRequest.GameAction);
                    actionResult.RoomMessage = String.Format("{0} heals {1} for {2} damage!", actionContext.Player.Name, actionContext.Target.Name, amount);
                    actionResult.PlayerMessage = String.Format("You heal {0} for {1} damage!", actionContext.Target.Name, amount);
                    actionResult.Amount = amount;
                    return actionResult;
                default:
                    throw new NotImplementedException("This action has not been implemented");
            }
        }

        public override ActionResult RecieveGameActionResult(GameActions gameAction, ActionResult actionResult, string playerName)
        {
            switch (gameAction)
            {
                case GameActions.Fight:
                    TakeDamage(actionResult.Amount);
                    actionResult.WasSuccessful = true;
                    actionResult.TargetMessage = String.Format("{0} attacks you for {1} damage!", playerName, actionResult.Amount);
                    actionResult.Amount = actionResult.Amount;
                    return actionResult;
                case GameActions.Repair:
                    actionResult.WasSuccessful = false;
                    actionResult.TargetMessage = String.Format("{0} tries to wrap you in duct tape but you wiggle free!", playerName);
                    return actionResult;
                case GameActions.Negotiate:
                    actionResult.WasSuccessful = true;
                    actionResult.TargetMessage = String.Format("{0} negotiates with you for {1} points!", playerName, actionResult.Amount);
                    actionResult.Amount = actionResult.Amount;
                    return actionResult;
                case GameActions.Heal:
                    RestoreHealth(actionResult.Amount);
                    actionResult.WasSuccessful = true;
                    actionResult.TargetMessage = String.Format("{0} heals you for {1} damage!", playerName, actionResult.Amount);
                    actionResult.Amount = actionResult.Amount;
                    return actionResult;
                default:
                    throw new NotImplementedException("This action has not been implemented");
            }
        }

        public abstract void TakeDamage(int dmg);

        public abstract void RestoreHealth(int health);

        public override ActionResult ProcessItem(ActionContext actionContext, IInventoryItem item)
        {
            AcceptItem(item);

            return new ActionResult()
            {
                WasSuccessful = true,
                RoomMessage = String.Format("{0} takes {1} and quickly hides it away.", this.Name, item.Name),
                PlayerMessage = String.Format("You take {0} and quickly hides it away.", item.Name)
            };
        }

        public abstract void AcceptItem(IInventoryItem item);
    }
}
