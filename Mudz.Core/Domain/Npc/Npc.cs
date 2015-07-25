using System;
using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Npc;
using Mudz.Data.Domain.GameEngine;

namespace Mudz.Core.Domain.Npc
{
	[Serializable]
    public abstract class Npc : BaseGameObject, INpc
    {
        protected Npc(string name)
        {
            Name = name;
            GameObjectType = GameObjectType.Npc;
            HitPoints = 100;
        }

        protected Npc()
            : this("")
        {
        }

        public NpcTypes NpcType { get; set; }

        public abstract string Greet();

        public abstract void ProcessCommand();

        public abstract string Respond();

        public void TakeDamage(int dmg)
        {
            HitPoints = HitPoints - dmg;
        }

        public void RestoreHealth(int health)
        {
            HitPoints = HitPoints + health;
        }

        #region Default Actions

        public override int CalculateGameAction(GameAction gameAction)
        {
            return 0;
        }

        public override IActionResult RecieveGameActionResult(GameAction gameAction, IActionResult actionResult, string playerName)
        {
            throw new NotImplementedException();
        }

        #endregion

        public override IActionResult ExecuteAction(IActionContext actionContext)
        {
            throw new NotImplementedException();
        }

        public override void CheckState()
        {
            throw new NotImplementedException();
        }
    }
}
