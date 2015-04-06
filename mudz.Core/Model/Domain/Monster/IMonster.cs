using System.Collections.Generic;
using mudz.Core.Model.Domain.InventoryItem;

namespace mudz.Core.Model.Domain.Monster
{
    public interface IMonster : IActor
    {
        BaseActor Statistics { get; set; }
        IList<IInventoryItem> Inventory { get; set; }
        bool HasItem { get; set; }
        double DropRate { get; set; }

    }
}
