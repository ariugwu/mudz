﻿namespace mudz.Core.Model.Domain.Npc
{
    public interface INpc : IGameObject
    {
        NpcTypes NpcType { get; set; }

        string Greet();
        string Respond();
        void ProcessCommand();
    }
}
