using System.Collections.Generic;

namespace GildedRose.InventoryManagement.Interfaces
{
	public interface IInventory
	{
		List<IStockItem> InventoryItems { get; set; }
		void AddStock(string name, int sellInValue, uint quality);
		void AddDay();
	}
}