using System.Collections.Generic;
using Mudz.Data.Domain;
using Mudz.Data.Domain.Inventory;

namespace Mudz.Common.Domain.Monster
{
	public interface IMonster : IActor
    {
        IList<IInventoryItem> Inventory { get; set; }
        bool HasItem(IInventoryItem item);
        double DropRate { get; set; }

    }
}
