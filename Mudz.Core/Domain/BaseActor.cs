﻿using System;
using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Inventory;
using Mudz.Common.Domain.Player.Inventory;
using Mudz.Core.Domain.GameEngine.Extensions;
using Mudz.Data.Domain.GameEngine;
using Mudz.Data.Domain.Localization;
using Mudz.Data.Domain.Player.Inventory;

namespace Mudz.Core.Domain
{
    [Serializable]
    public abstract class BaseActor : BaseGameObject, IActor
    {
        #region Game Engine

        public int Stamina { get; set; }

        #endregion

        #region Actor Stats

        public abstract ActorGenderType Gender { get; set; }
        public ActorState ActorState { get; set; }

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
                this.GameObjectState = GameObjectState.OutOfPlay;
                this.ActorState = ActorState.Dead;
            }
        }

        private void CheckStamina()
        {
            if (IsExhausted())
            {
                this.ActorState = ActorState.Exhausted;
            }
        }

        private bool IsExhausted()
        {
            return this.Stamina <= 0;
        }

        private bool HasEnoughStaminaForAction(GameAction gameAction)
        {
            return this.Stamina >= GetStaminaCostByActionType(gameAction);
        }

        public bool IsAlive()
        {
            return this.HitPoints > 0;
        }

        private bool IsDisabled()
        {
            return ActorState == ActorState.Disabled;
        }

        private IActionResult CannotRespond(IActionContext actionContext)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                RoomMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceName.CannotRespondRoomMessage], this.Name),
                PlayerMessage = TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceName.CannotRespondPlayerMessage]
            };
        }

        private IActionResult NotEnoughStamina(IActionContext actionContext)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                RoomMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceName.NotEnoughStaminaRoomMessage], this.Name),
                PlayerMessage = TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceName.NotEnoughStaminaPlayerMessage]
            };

        }

        public abstract int GetStaminaCostByActionType(GameAction gameAction);

        public override IActionResult ExecuteAction(IActionContext actionContext)
        {
            if (IsExhausted() || IsDisabled()) return CannotRespond(actionContext);
            if (!HasEnoughStaminaForAction(actionContext.GameRequest.GameAction)) return NotEnoughStamina(actionContext);

            var actionResult = new ActionResult() { GameAction = actionContext.GameRequest.GameAction };
            int amount = 0;

            amount = this.CalculateGameAction(actionContext.GameRequest.GameAction);
            actionResult.Fill(actionContext, amount);

            return actionResult;
        }

        public override IActionResult RecieveGameActionResult(GameAction gameAction, IActionResult actionResult, string playerName)
        {
            switch (gameAction)
            {
                case GameAction.Fight:
                    TakeDamage(actionResult.Amount);
                    actionResult.WasSuccessful = true;
                    actionResult.TargetMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceName.FightTargetMessage], playerName, actionResult.Amount);
                    actionResult.Amount = actionResult.Amount;
                    return actionResult;
                case GameAction.Repair:
                    actionResult.WasSuccessful = false;
                    actionResult.TargetMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceName.RepairTargetMessage], playerName);
                    return actionResult;
                case GameAction.Negotiate:
                    actionResult.WasSuccessful = true;
                    actionResult.TargetMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceName.NegotiateTargetMessage], playerName, actionResult.Amount);
                    actionResult.Amount = actionResult.Amount;
                    return actionResult;
                case GameAction.Heal:
                    RestoreHealth(actionResult.Amount);
                    actionResult.WasSuccessful = true;
                    actionResult.TargetMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceName.HealTargetMessage], playerName, actionResult.Amount);
                    actionResult.Amount = actionResult.Amount;
                    return actionResult;
                default:
                    throw new NotImplementedException("This action has not been implemented");
            }
        }

        public abstract void TakeDamage(int dmg);

        public abstract void RestoreHealth(int health);

        public override IActionResult ProcessItem(IActionContext actionContext, IInventoryItem item)
        {

            if (actionContext.GameRequest.GameAction.Equals(GameAction.EquipItem))
            {
                if (item.InventoryType.Equals(InventoryType.PlayerWeapon))
                {
                    EquipWeapon((IPlayerWeapon)item);
                }
                else if (item.InventoryType.Equals(InventoryType.PlayerWearable))
                {
                    EquipWearable((IPlayerWearable)item);
                }
            }
            else
            {
                AcceptItem(item);

            }

            return new ActionResult()
        {
            GameAction = actionContext.GameRequest.GameAction,
            WasSuccessful = true,
            RoomMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceName.GetItemRoomMessage], this.Name, item.Name),
            PlayerMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceName.GetItemPlayerMessage], item.Name)
        };
        }

        public abstract void AcceptItem(IInventoryItem item);
        public abstract void EquipWeapon(IPlayerWeapon weapon);
        public abstract void EquipWearable(IPlayerWearable wearable);
    }
}
