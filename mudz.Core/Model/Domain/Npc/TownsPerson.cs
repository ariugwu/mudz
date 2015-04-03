namespace mudz.Core.Model.Domain.Npc
{
    public class TownsPerson : Npc
    {
        public TownsPerson(string name)
            : base(name)
        {
            NpcType = NpcTypes.TownsPerson;
        }

        public override void TakeDamage(double dmg)
        {
            throw new System.NotImplementedException();
        }

        public override void Heal(double health)
        {
            throw new System.NotImplementedException();
        }
    }
}
