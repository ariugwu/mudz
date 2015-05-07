using System;
using mudz.Core.Model.Domain.GameEngine;

namespace mudz.Core.Model.Domain
{
    public abstract class BaseActor : BaseGameObject, IActor
    {
        #region Game Engine 
        
        public double Stamina { get; set; }
        
        #endregion

        #region Actor Stats

        public abstract ActorGenderTypes Gender { get; set; }
        public ActorStates ActorState { get; set; }

        public double Health { get; set; }
        public double Strength { get; set; }
        public double Intellect { get; set; }
        public double Wisdom { get; set; }
        public double Agility { get; set; }
        public double Willpower { get; set; }
        public double Charm { get; set; }
        public double Endurance { get; set; }
        
        #endregion

        public override GameResponse Execute(GameRequest request)
        {
            var actionType = request.GameAction;
            var gameResponse = new GameResponse(){ WasSuccessful = true};
            Double amount = 0D;

            switch (actionType)
            {
                case GameActions.Fight:
                    if (ActorState.Name == "Disabled")
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
