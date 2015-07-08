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
        public string Message { get; set; }
        public int Amount { get; set; }
        public bool WasSuccessful { get; set; }
        public DateTime Created { get; set; }
    }
}
