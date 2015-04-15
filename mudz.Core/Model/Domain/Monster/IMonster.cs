using System.Collections.Generic;
using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Model.Domain.Monster
{
    public interface IMonster : IActor
    {
        IList<IInventoryItem> Inventory { get; set; }
        bool HasItem(IInventoryItem item);
        double DropRate { get; set; }

    }
}
