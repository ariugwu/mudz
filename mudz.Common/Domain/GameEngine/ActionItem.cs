using System;

namespace mudz.Common.Domain.GameEngine
{
    public class ActionItem
    {
        public GameActions GameAction { get; set; }
        public string Message { get; set; }
        public int Amount { get; set; }
        public bool WasSuccessful { get; set; }
        public DateTime Created { get; set; }
    }
}
