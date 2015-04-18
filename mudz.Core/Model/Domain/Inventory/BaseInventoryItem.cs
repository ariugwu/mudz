namespace mudz.Core.Model.Domain.Inventory
{
    public abstract class BaseInventoryItem : IInventoryItem
    {
        public abstract InventoryTypes InventoryType { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Dexterity { get; set; }

        public double HitPoints { get; set; }

        public GameObjectTypes GameObjectType { get { return GameObjectTypes.InventoryItem; } }

        public abstract bool IsDestructible { get; }

        public abstract bool IsAttainable { get; }

        public void TakeDamage(double dmg)
        {

        }

        public void RestoreHealth(double health)
        {

        }
    }
}
