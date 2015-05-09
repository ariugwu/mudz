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

        public override void TakeDamage(int dmg)
        {
            HitPoints = HitPoints - dmg;
        }

        public override void RestoreHealth(int health)
        {
            HitPoints = HitPoints + health;
        }

        #region Default Actions

        public override int Fight()
        {
            return 0;
        }
        public override int Heal()
        {
            return 0;
        }

        public override int Negotiate()
        {
            return 0;
        }

        public override int Repair()
        {
            return 0;
        }

        #endregion

        public override GameResponse Execute(GameRequest request)
        {
            throw new NotImplementedException();
        }

        public override void CheckState()
        {
            throw new NotImplementedException();
        }
    }
}
