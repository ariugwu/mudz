using System;

namespace mudz.Core.Model.Domain.Npc
{
    public abstract class Npc : BaseGameObject, INpc
    {
        protected Npc(string name)
        {
            Name = name;
            GameObjectType = GameObjectTypes.Npc;
            HitPoints = 100;
        }

        protected Npc() : this("")
        {
        }

        public NpcTypes NpcType { get; set; }

        public abstract string Greet();

        public abstract void ProcessCommand();

        public abstract string Respond();

        public override void TakeDamage(double dmg)
        {
            HitPoints = HitPoints - dmg;
        }

        public override void Heal(double health)
        {
            HitPoints = HitPoints + health;
        }
    }
}
