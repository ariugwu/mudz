using System;
using mudz.Common.Domain.GameEngine;

namespace mudz.Common.Domain.easytcp.Interpreter
{
    [Serializable]
    public abstract class AbstractExpression
    {
        public GameActions GameAction { get; set; }
        public string PlayerName { get; set; }
        public string TargetName { get; set; }

        public bool HasTarget { get; set; }
        public bool HasPlayer { get; set; }

        protected Object _context;

        public void Interpret(Object context)
        {
            _context = context;

            EvaluateContext();

            if (GameAction == GameActions.None)
            {
                return;
            }

            if (GameAction != GameActions.Login)
            {
                GetGameAction();
            }

            GetPlayerName();

            if (!HasTarget) return;
            GetTargetName();
        }

        public abstract void EvaluateContext();

        public abstract void GetPlayerName();
        public abstract void GetGameAction();
        public abstract void GetTargetName();
    }
}
