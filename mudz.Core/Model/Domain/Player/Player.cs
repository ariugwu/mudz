namespace mudz.Core.Model.Domain.Player
{
    public abstract class Player : BaseGameObject, IPlayer
    {
        public Player(string name)
        {
            Name = name;
            GameObjectType = GameObjectTypes.Player;
        }

        public Player()
        {
            GameObjectType = GameObjectTypes.Player;
        }

        public PlayerTypes PlayerType { get; set; }

        public abstract void Repair();

        public abstract void Attack();

        public abstract void Heal();

        public abstract void Negotiate();

        public abstract void Move();
    }
}
