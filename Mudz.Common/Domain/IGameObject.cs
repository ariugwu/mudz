using System;
using Mudz.Common.Domain.GameEngine;

namespace Mudz.Common.Domain
{
    public interface IGameObject : IGameCommand
    {
        Guid GameObjectKey { get; set; }

        string Name { get; }
        string Description { get; }

        int Dexterity { get; }
        int HitPoints { get; set; }

        GameObjectType GameObjectType { get;}
        GameObjectState GameObjectState { get; set; }

        bool IsDestructible { get; }
        bool IsAttainable { get; }

        int CalculateGameAction(GameAction gameAction);

        IActionResult RecieveGameActionResult(GameAction gameAction, IActionResult actionResult, string playerName);

    }
}
