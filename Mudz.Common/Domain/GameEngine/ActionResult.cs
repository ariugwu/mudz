using System;
using Mudz.Data.Domain.Localization;

namespace Mudz.Common.Domain.GameEngine
{
    [Serializable]
    public class ActionResult
    {
        public ActionResult()
        {
            Created = DateTime.Now;
        }

        public GameActions GameAction { get; set; }
        public string PlayerMessage { get; set; }
        public string TargetMessage { get; set; }
        public string RoomMessage { get; set; }
        public int Amount { get; set; }
        public bool WasSuccessful { get; set; }
        public DateTime Created { get; set; }

        public void FillResult(ActionContext actionContext, int amount)
        {
            this.WasSuccessful = true;
            this.RoomMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.FightRoomMessage], actionContext.Player.Name, actionContext.Target.Name, amount);
            this.PlayerMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.FightPlayerMessage], actionContext.Target.Name, amount);
            this.Amount = amount;
        }
    }
}
