using System;

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
            var playerMessage = new Localization.Template.PlayerMessage();
            var roomMessage = new Localization.Template.RoomMessage();
            var targetMessage = new Localization.Template.TargetMessage();

            this.WasSuccessful = true;
            this.RoomMessage = roomMessage.GetResource(actionContext, amount);
            this.PlayerMessage = playerMessage.GetResource(actionContext, amount);
            this.Amount = amount;
        }
    }
}
