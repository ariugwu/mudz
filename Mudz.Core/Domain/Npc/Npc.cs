using System;
using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Npc;
using Mudz.Core.Model.Domain;

namespace Mudz.Core.Domain.Npc
{
    [Serializable]
    public abstract class Npc : BaseGameObject, INpc
    {
        protected Npc(string name)
        {
            Name = name;
            GameObjectType = GameObjectTypes.Npc;
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

        public override int CalculateGameAction(GameActions gameAction)
        {
            return 0;
        }

        public override ActionResult RecieveGameActionResult(GameActions gameAction, ActionResult actionResult, string playerName)
        {
            throw new NotImplementedException();
        }

        #endregion

        public override ActionResult ExecuteAction(ActionContext actionContext)
        {
            throw new NotImplementedException();
        }

        public override void CheckState()
        {
            throw new NotImplementedException();
        }
    }
}
