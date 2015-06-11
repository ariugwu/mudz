using System;
using mudz.Common.Domain.Npc;

namespace mudz.Core.Model.Domain.Npc
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

    }
}
