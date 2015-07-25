using System;

namespace Mudz.Common.Domain
{
    [Serializable]
    public class ActorState: GameObjectState
    {
        public static ActorState Alive = new ActorState() { Name = "Alive", Description = ""};
        public static ActorState Infected = new ActorState() { Name = "Infected", Description = "" };
        public static ActorState Dead = new ActorState() { Name = "Dead", Description = "" };
        public static ActorState Disabled = new ActorState() { Name = "Disabled", Description = "" };
        public static ActorState Drunk = new ActorState() { Name = "Drunk", Description = "" };
        public static ActorState Angry = new ActorState() { Name = "Angry", Description = "" };
        public static ActorState Depressed = new ActorState() { Name = "Depressed", Description = "" };
        public static ActorState Exhausted = new ActorState() { Name = "Exhausted", Description = "With no stamina left it's difficult to do anything." };
    }
}
