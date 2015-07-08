using System.Collections.Generic;
using Mudz.Common.Domain.Inventory;

namespace Mudz.Common.Domain.Monster
{
    public interface IMonster : IActor
    {
        IList<IInventoryItem> Inventory { get; set; }
        bool HasItem(IInventoryItem item);
        double DropRate { get; set; }

    }
}
