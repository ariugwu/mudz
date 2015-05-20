using System.Collections.Generic;
using mudz.Core.Model.Domain.GameEngine;

namespace mudz.Core.Model.Domain.Player
{
    public interface IPlayerActionStrategy
    {
        void SetStats(IActor actor);

        Dictionary<GameActions, int> ActionStaminaCostMap { get; }

        int Repair(IActor actor);
        int Negotiate(IActor actor);

        int Attack(IActor actor);
        int Heal(IActor actor);

        void RestoreHealth(IActor actor, int health);
        void TakeDamage(IActor actor, int dmg);

        string GetClassDescription();

    }
}
