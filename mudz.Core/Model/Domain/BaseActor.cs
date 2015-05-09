using System;
using mudz.Core.Model.Domain.GameEngine;

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
            if (this.HitPoints <= 0)
            {
                this.GameObjectState = GameObjectStates.OutOfPlay;
                this.ActorState = ActorStates.Dead;
            }
        }

        public override GameResponse Execute(GameRequest request)
        {
            var actionType = request.GameAction;
            var gameResponse = new GameResponse(){ WasSuccessful = true};
            int amount = 0;

            switch (actionType)
            {
                case GameActions.Fight:
                    if (ActorState == ActorStates.Disabled)
                    {
                        gameResponse.WasSuccessful = false;
                        gameResponse.Message = String.Format("{0} struggles move!", this.Name);
                    }
                    else
                    {
                        amount = this.Fight();
                        gameResponse.Message = String.Format("{0} attacks for {1}!", this.Name, amount);   
                    }

                    gameResponse.Amount = amount;
                    return gameResponse;
                case GameActions.Repair:
                    this.Repair();
                    return new GameResponse(){ Message = String.Format("{0} repairs!", this.Name)};
                case GameActions.Negotiate:
                    this.Negotiate();
                    return new GameResponse(){ Message = String.Format("{0} negotiates!", this.Name)};
                case GameActions.Heal:
                    amount = this.Heal();
                    return new GameResponse(){ WasSuccessful = true, Message = String.Format("{0} heals {1} for {2} damage!", request.Sender.Name, request.Target.Name, amount), Amount = amount};
                default:
                    throw new NotImplementedException("This action has not been implemented");
            }
        }
    }
}
