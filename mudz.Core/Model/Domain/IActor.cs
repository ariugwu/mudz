namespace mudz.Core.Model.Domain
{
    public interface IActor : IGameObject
    {
        ActorGenderTypes Gender  { get; set; }

        double Health { get; set; }
        double Stamina { get; set; }

        double Strength { get; set; }
        double Intellect { get; set; }
        double Wisdom { get; set; }
        double Agility { get; set; }
        double Willpower { get; set; }
        double Charm { get; set; }
        double Endurance { get; set; }
    }
}
