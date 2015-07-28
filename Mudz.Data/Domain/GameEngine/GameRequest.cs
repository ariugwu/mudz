using System;
using System.Collections.Generic;
using Mudz.Common.Domain.GameEngine;
using Mudz.Data.Domain.EasyTcp.Interpreter;

namespace Mudz.Data.Domain.GameEngine
{
    [Serializable]
    public class GameRequest : AbstractExpression, IGameRequest
    {

        public GameRequest(string playerName)
        {
            if (playerName == null)
            {
                GameAction = GameAction.Login;
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
            if (_args.Length > 2) GameAction = GameAction.None;
            if (_args.Length == 2) HasTarget = true;
            if (_args.Length >= 1) Command = _args[0];
        }

        public override void GetPlayerName()
        {
            if (GameAction == GameAction.Login)
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

        public GameAction GetGameAction(string command)
        {
            command = command.Trim().ToLower();

            return (_commandActionMap.ContainsKey(command)) ? _commandActionMap[command] : GameAction.None;
        }

        private Dictionary<string, GameAction> _commandActionMap = new Dictionary<string, GameAction>()
        {
            {"fight", GameAction.Fight},
            {"attack", GameAction.Fight},
            {"negotiate", GameAction.Negotiate},
            {"repair", GameAction.Repair},
            {"heal", GameAction.Heal},
            {"look", GameAction.LookAround},
            {"inspect", GameAction.LookAt},
            {"none", GameAction.None},
            {"get", GameAction.Get},
            {"login", GameAction.Login},
            {"inventory", GameAction.SeeInventory},
            {"equip", GameAction.EquipItem}
        };
    }
}
