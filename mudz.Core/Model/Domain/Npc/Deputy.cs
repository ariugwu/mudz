namespace mudz.Core.Model.Domain.Npc
{
    public class Deputy : Npc
    {
        public Deputy(string name) : base(name)
        {
           NpcType = NpcTypes.Deputy;
        }

    }
}
