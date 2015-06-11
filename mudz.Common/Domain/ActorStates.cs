using System;

namespace mudz.Common.Domain
{
    [Serializable]
    public class ActorStates: GameObjectStates
    {
        public static ActorStates Alive = new ActorStates() { Name = "Alive", Description = ""};
        public static ActorStates Infected = new ActorStates() { Name = "Infected", Description = "" };
        public static ActorStates Dead = new ActorStates() { Name = "Dead", Description = "" };
        public static ActorStates Disabled = new ActorStates() { Name = "Disabled", Description = "" };
        public static ActorStates Drunk = new ActorStates() { Name = "Drunk", Description = "" };
        public static ActorStates Angry = new ActorStates() { Name = "Angry", Description = "" };
        public static ActorStates Depressed = new ActorStates() { Name = "Depressed", Description = "" };
        public static ActorStates Exhausted = new ActorStates() { Name = "Exhausted", Description = "With no stamina left it's difficult to do anything." };
    }
}
