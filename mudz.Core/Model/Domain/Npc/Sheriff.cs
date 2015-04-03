namespace mudz.Core.Model.Domain.Npc
{
    public class Sheriff : Npc
    {
        public Sheriff(string name)
            : base(name)
        {
            NpcType = NpcTypes.Sheriff;
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
