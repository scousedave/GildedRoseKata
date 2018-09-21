using GildedRose.InventoryManagement.QualityCalculators;

namespace GildedRose.InventoryManagement.StockItems
{
	public class NormalItem : StockItemBase
	{
		public override string Name => "Normal Item";

		public NormalItem(int sellInValue, uint quality) 
			: base(sellInValue, quality, new NormalQualityCalculator())
		{
		}

	}
}
