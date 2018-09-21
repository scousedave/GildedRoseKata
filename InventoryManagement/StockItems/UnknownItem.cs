using GildedRose.InventoryManagement.Interfaces;
using GildedRose.InventoryManagement.QualityCalculators;

namespace GildedRose.InventoryManagement.StockItems
{
	public class UnknownItem : StockItemBase
	{
		public override string Name => "NO SUCH ITEM";

		public UnknownItem(int sellInValue, uint quality) 
			: base(sellInValue, quality, new NoActionQualityCalculator())
		{
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
