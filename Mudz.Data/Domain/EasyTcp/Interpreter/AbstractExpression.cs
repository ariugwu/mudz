using System;
using Mudz.Common.Domain.GameEngine;
using Mudz.Data.Domain.GameEngine;

namespace Mudz.Data.Domain.EasyTcp.Interpreter
{
    [Serializable]
    public abstract class AbstractExpression
    {
        public GameAction GameAction { get; set; }
        
        public string PlayerName { get; set; }
        public string TargetName { get; set; }
        public string Command { get; set; }

        public bool HasTarget { get; set; }
        public bool HasPlayer { get; set; }

        protected Object _context;

        public void Interpret(Object context)
        {
            _context = context;

            EvaluateContext();

            if (GameAction == GameAction.None)
            {
                return;
            }

            if (GameAction != GameAction.Login)
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
