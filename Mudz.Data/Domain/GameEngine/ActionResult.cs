using System;
using Mudz.Common.Domain.GameEngine;

namespace Mudz.Data.Domain.GameEngine
{
    [Serializable]
    public class ActionResult : IActionResult
    {
        public ActionResult()
        {
            Created = DateTime.Now;
        }

        public GameAction GameAction { get; set; }
        public string PlayerMessage { get; set; }
        public string TargetMessage { get; set; }
        public string RoomMessage { get; set; }
        public int Amount { get; set; }
        public bool WasSuccessful { get; set; }
        public DateTime Created { get; set; }

    }
}
