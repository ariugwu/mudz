using System;

namespace Mudz.Common.Domain.GameEngine
{
    public interface IActionResult
    {
        GameAction GameAction { get; set; }
        string PlayerMessage { get; set; }
        string TargetMessage { get; set; }
        string RoomMessage { get; set; }
        int Amount { get; set; }
        bool WasSuccessful { get; set; }
        DateTime Created { get; set; }
    }
}