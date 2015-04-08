using System;

namespace mudz.Core.Model.Domain.Player
{
    public class Player : BaseActor, IPlayer
    {
        public Player(string name, PlayerTypes playerType, IPlayerActionStrategy actionStrategy)
        {
            Name = name;
            PlayerType = playerType;
            GameObjectType = GameObjectTypes.Player;
            _actionStrategy = actionStrategy;
        }

        public Player() : this("", PlayerTypes.ArmyVet, new ArmyVet())
        {
            
        }

        private IPlayerActionStrategy _actionStrategy;

        public PlayerTypes PlayerType { get; set; }

        public BaseActor Statistics { get; set; }

        public int Experience { get; set; }

        public int Level { get; set; }

        public void Inspect()
        {
            _actionStrategy.Inspect();
        }

        public void Repair()
        {
            _actionStrategy.Repair();
        }

        public override void Attack()
        {
            _actionStrategy.Attack();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public void Negotiate()
        {
            _actionStrategy.Negotiate();
        }

        public override void TakeDamage(double dmg)
        {
            _actionStrategy.TakeDamage(dmg);
        }

        public override void Heal(double health)
        {
            _actionStrategy.Heal(health);
        }
    }
}
