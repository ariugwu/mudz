using System;
using mudz.Core.Model.Domain.GameEngine;
using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Model.Domain
{
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

        private GameResponse CannotRespond(GameResponse gameResponse)
        {

            gameResponse.WasSuccessful = false;
            gameResponse.Message = String.Format("{0} begins to move and then collapses!", this.Name);

            return gameResponse;
        }

        private GameResponse NotEnoughStamina(GameResponse gameResponse)
        {

            gameResponse.WasSuccessful = false;
            gameResponse.Message = String.Format("{0} does not have enough stamina (turns) to complete this action!", this.Name);

            return gameResponse;
        }

        public abstract int GetStaminaCostByActionType(GameActions gameAction);

        public override GameResponse ExecuteAction(GameRequest request)
        {
            var actionType = request.GameAction;
            var gameResponse = new GameResponse() { WasSuccessful = true };
            int amount = 0;

            if (IsExhausted() || IsDisabled()) return CannotRespond(gameResponse);
            if (!HasEnoughStaminaForAction(actionType)) return NotEnoughStamina(gameResponse);

                switch (actionType)
                {
                    case GameActions.Fight:
                        amount = this.Fight();
                        gameResponse.Message = String.Format("{0} attacks for {1} damage!", this.Name, amount);
                        gameResponse.Amount = amount;
                        return gameResponse;
                    case GameActions.Repair:
                        amount = this.Repair();
                        gameResponse.Message = String.Format("{0} repairs for {1} hit points!", this.Name, amount);
                        gameResponse.Amount = amount;
                        return gameResponse;
                    case GameActions.Negotiate:
                        amount = this.Negotiate();
                        gameResponse.Message = String.Format("{0} negotiates for points!", this.Name, amount);
                        gameResponse.Amount = amount;
                        return gameResponse;
                    case GameActions.Heal:
                        amount = this.Heal();
                        gameResponse.Message = String.Format("{0} heals {1} for {2} damage!", request.Sender.Name, request.Target.Name, amount);
                        gameResponse.Amount = amount;
                        return gameResponse;
                    default:
                        throw new NotImplementedException("This action has not been implemented");
                }
        }

        public override GameResponse ProcessItem(IInventoryItem item)
        {
            AcceptItem(item);

            return new GameResponse()
            {
                Request = new GameRequest(),
                WasSuccessful = true,
                Message = String.Format("{0} takes {1} and quickly hides it away.", this.Name, item.Name)
            };
        }

        public abstract void AcceptItem(IInventoryItem item);
    }
}
