using System;
using System.Collections.Generic;
using Mudz.Data.Domain.EasyTcp.Interpreter;

namespace Mudz.Data.Domain.GameEngine
{
    [Serializable]
    public class GameRequest : AbstractExpression
    {

        public GameRequest(string playerName)
        {
            if (playerName == null)
            {
                GameAction = GameActions.Login;
            }
            else
            {
                PlayerName = playerName;
                HasPlayer = true;
            }
        }

        private string[] _args;

        public override void EvaluateContext()
        {
            _args = ((string)_context).Split(' ');
            if (_args.Length > 2) GameAction = GameActions.None;
            if (_args.Length == 2) HasTarget = true;
            if (_args.Length >= 1) Command = _args[0];
        }

        public override void GetPlayerName()
        {
            if (GameAction == GameActions.Login)
            {
                PlayerName = _args[0];
                HasPlayer = true;
            }
        }

        public override void GetGameAction()
        {
            GameAction = GetGameAction(Command);
        }

        public override void GetTargetName()
        {
            TargetName = _args[1];
        }

        private GameActions GetGameAction(string command)
        {
            command = command.Trim().ToLower();

            return (_commandActionMap.ContainsKey(command)) ? _commandActionMap[command] : GameActions.None;
        }

        private Dictionary<string, GameActions> _commandActionMap = new Dictionary<string, GameActions>()
        {
            {"fight", GameActions.Fight},
            {"attack", GameActions.Fight},
            {"negotiate", GameActions.Negotiate},
            {"repair", GameActions.Repair},
            {"heal", GameActions.Heal},
            {"look", GameActions.LookAround},
            {"inspect", GameActions.LookAt},
            {"none", GameActions.None},
            {"get", GameActions.Get},
            {"login", GameActions.Login}
        };
    }
}
