using System;
using mudz.Core.Model.Domain.GameEngine;

namespace mudz.Core.Model.Domain
{
    public abstract class BaseActor : BaseGameObject, IActor
    {
        #region Default Actions

        public override double Fight()
        {
            return 0;
        }
        public override double Heal()
        {
            return 10;
        }

        public override double Negotiate()
        {
            return 0;
        }

        public override double Repair()
        {
            return 0;
        }

        #endregion 

        #region Game Engine 
        
        public double Stamina { get; set; }
        
        #endregion

        #region Actor Stats

        public abstract ActorGenderTypes Gender { get; set; }

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

            switch (actionType)
            {
                case GameActions.Fight:
                    this.Fight();
                    return new GameResponse(){ Message = String.Format("{0}, fights!", this.Name)};
                case GameActions.Repair:
                    this.Repair();
                    return new GameResponse(){ Message = String.Format("{0} repairs!", this.Name)};
                case GameActions.Negotiate:
                    this.Negotiate();
                    return new GameResponse(){ Message = String.Format("{0} negotiates!", this.Name)};
                case GameActions.Heal:
                    var amount = this.Heal();
                    return new GameResponse(){ Message = String.Format("{0} heals {1} for {2} damage!", request.Sender.Name, request.Target.Name, amount), Amount = amount};
                default:
                    throw new NotImplementedException("This action has not been implemented");
            }
        }
    }
}
