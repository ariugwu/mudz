using System;

namespace mudz.Core.Model.Domain.Player
{
    public abstract class BasePlayer : BaseActor, IPlayer
    {
        protected BasePlayer(string name)
        {
            Name = name;
            GameObjectType = GameObjectTypes.Player;
        }

        protected BasePlayer() : this("")
        {
            
        }

        public PlayerTypes PlayerType { get; set; }

        public BaseActor Statistics { get; set; }

        public int Experience { get; set; }

        public int Level { get; set; }

        public void Inspect()
        {
            throw new NotImplementedException();
        }

        public abstract void Repair();

        public abstract void Negotiate();

    }
}
