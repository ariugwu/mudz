namespace mudz.Core.Model.Domain.Npc
{
    public class ShopKeeper : Npc
    {
        public ShopKeeper(string name): base(name)
        {
           NpcType = NpcTypes.ShopKeeper;
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
