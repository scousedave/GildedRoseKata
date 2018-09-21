namespace GildedRose.InventoryManagement.Interfaces
{
	public interface IStockItemFactory
	{
		IStockItem Create(string itemName, int sellInValue, uint quality);
	}
}