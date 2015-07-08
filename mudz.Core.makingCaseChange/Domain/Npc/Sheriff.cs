using System;
using Mudz.Common.Domain.Npc;

namespace Mudz.Core.Domain.Npc
{
        [Serializable]
    public class Sheriff : Npc
    {
        public Sheriff(string name)
            : base(name)
        {
            NpcType = NpcTypes.Sheriff;
        }

        public override string Greet()
        {
            throw new System.NotImplementedException();
        }

        public override void ProcessCommand()
        {
            throw new System.NotImplementedException();
        }

        public override string Respond()
        {
            throw new System.NotImplementedException();
        }

    }
}
