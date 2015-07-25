using System;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Npc;

namespace Mudz.Core.Domain.Npc
{
    [Serializable]
    public class TownsPerson : Npc
    {
        public TownsPerson(string name)
            : base(name)
        {
            NpcType = NpcTypes.TownsPerson;
        }

        public override string Greet()
        {
            return "Hello! What brings you to this place?";
        }

        public override string Respond()
        {
            throw new System.NotImplementedException();
        }

        public override void ProcessCommand()
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult RecieveGameActionResult(GameAction gameAction, IActionResult actionResult, string playerName)
        {
            throw new NotImplementedException();
        }
    }
}
