using System;

namespace mudz.Core.Model.Domain.Player
{
    public abstract class Player : BaseGameObject, IPlayer
    {
        protected Player(string name)
        {
            Name = name;
            GameObjectType = GameObjectTypes.Player;
        }

        protected Player() : this("")
        {
            
        }

        public PlayerTypes PlayerType { get; set; }

        public int Experience { get; set; }

        public int Level { get; set; }

        public void Inspect()
        {
            throw new NotImplementedException();
        }

        public abstract void Repair();

        public abstract void Attack();

        public abstract void Heal();

        public abstract void Negotiate();

        public abstract void Move();
    }
}
