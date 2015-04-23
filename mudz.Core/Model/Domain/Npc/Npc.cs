using System;
using mudz.Core.Model.Domain.GameEngine;

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

        public override void RestoreHealth(double health)
        {
            HitPoints = HitPoints + health;
        }

        #region Default Actions

        public override double Fight()
        {
            return 0;
        }
        public override double Heal()
        {
            return 0;
        }

        public override double Negotiate()
        {
            return 0;
        }

        public override double Repair()
        {
            return 0;
        }

        #endregion

        public override GameResponse Execute(GameRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
