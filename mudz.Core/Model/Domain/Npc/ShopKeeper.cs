using System;
using mudz.Common.Domain.Npc;

namespace mudz.Core.Model.Domain.Npc
{
        [Serializable]
    public class ShopKeeper : Npc
    {
        public ShopKeeper(string name): base(name)
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
