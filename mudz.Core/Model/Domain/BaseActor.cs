namespace mudz.Core.Model.Domain
{
    public abstract class BaseActor : BaseGameObject, IActor
    {
        public abstract double Attack();
        public abstract double Heal();
        public abstract void Move();

        public double Health { get; set; }
        public double Strength { get; set; }
        public double Intellect { get; set; }
        public double Wisdom { get; set; }
        public double Agility { get; set; }
        public double Willpower { get; set; }
        public double Charm { get; set; }
        public double Endurance { get; set; }
    }
}
