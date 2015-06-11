using System.Collections.Generic;
using mudz.Common.Domain.Inventory;

namespace mudz.Common.Domain.Monster
{
    public interface IMonster : IActor
    {
        IList<IInventoryItem> Inventory { get; set; }
        bool HasItem(IInventoryItem item);
        double DropRate { get; set; }

    }
}
