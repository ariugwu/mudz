namespace mudz.Core.Model.Domain.Npc
{
    public interface INpc
    {
        NpcTypes NpcType { get; set; }

        void Greet();
        void ProcessCommand();
        void Respond();
    }
}
