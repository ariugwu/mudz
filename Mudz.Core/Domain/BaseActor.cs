using System;
using Mudz.Core.Domain.GameEngine.Extensions;
using Mudz.Data.Domain;
using Mudz.Data.Domain.GameEngine;
using Mudz.Data.Domain.Inventory;
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
                RoomMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.CannotRespondRoomMessage], this.Name),
                PlayerMessage = TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.CannotRespondPlayerMessage]
            };
        }

        private ActionResult NotEnoughStamina(ActionContext actionContext)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                RoomMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.NotEnoughStaminaRoomMessage], this.Name),
                PlayerMessage = TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.NotEnoughStaminaPlayerMessage]
            };

        }

        public abstract int GetStaminaCostByActionType(GameActions gameAction);

        public override ActionResult ExecuteAction(ActionContext actionContext)
        {
            if (IsExhausted() || IsDisabled()) return CannotRespond(actionContext);
            if (!HasEnoughStaminaForAction(actionContext.GameRequest.GameAction)) return NotEnoughStamina(actionContext);

            var actionResult = new ActionResult();
            int amount = 0;

            amount = this.CalculateGameAction(actionContext.GameRequest.GameAction);
            actionResult.FillResult(actionContext, amount);

            return actionResult;
        }

        public override ActionResult RecieveGameActionResult(GameActions gameAction, ActionResult actionResult, string playerName)
        {
            switch (gameAction)
            {
                case GameActions.Fight:
                    TakeDamage(actionResult.Amount);
                    actionResult.WasSuccessful = true;
                    actionResult.TargetMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.FightTargetMessage], playerName, actionResult.Amount);
                    actionResult.Amount = actionResult.Amount;
                    return actionResult;
                case GameActions.Repair:
                    actionResult.WasSuccessful = false;
                    actionResult.TargetMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.RepairTargetMessage], playerName);
                    return actionResult;
                case GameActions.Negotiate:
                    actionResult.WasSuccessful = true;
                    actionResult.TargetMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.NegotiateTargetMessage], playerName, actionResult.Amount);
                    actionResult.Amount = actionResult.Amount;
                    return actionResult;
                case GameActions.Heal:
                    RestoreHealth(actionResult.Amount);
                    actionResult.WasSuccessful = true;
                    actionResult.TargetMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.HealTargetMessage], playerName, actionResult.Amount);
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
                RoomMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.GetItemRoomMessage], this.Name, item.Name),
                PlayerMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.GetItemPlayerMessage], item.Name)
            };
        }

        public abstract void AcceptItem(IInventoryItem item);
    }
}
