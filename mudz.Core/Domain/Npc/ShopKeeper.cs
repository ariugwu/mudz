using System;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Npc;

namespace Mudz.Core.Model.Domain.Npc
{
    [Serializable]
    public class ShopKeeper : Core.Domain.Npc.Npc
    {
        public ShopKeeper(string name)
            : base(name)
        {
            NpcType = NpcTypes.ShopKeeper;
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
