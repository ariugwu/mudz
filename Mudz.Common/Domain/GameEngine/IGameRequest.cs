using System;

namespace Mudz.Common.Domain.GameEngine
{
    public interface IGameRequest
    {
        void EvaluateContext();
        void GetPlayerName();
        void GetGameAction();
        void GetTargetName();
        GameAction GetGameAction(string command);
        GameAction GameAction { get; set; }
        string PlayerName { get; set; }
        string TargetName { get; set; }
        string Command { get; set; }
        bool HasTarget { get; set; }
        bool HasPlayer { get; set; }
        void Interpret(Object context);
    }
}