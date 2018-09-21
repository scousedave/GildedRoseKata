using GildedRose.InventoryManagement.QualityCalculators;

namespace GildedRose.InventoryManagement.StockItems
{
	public class BackstagePasses : StockItemBase
	{
		public override string Name => "Backstage passes";

		public BackstagePasses(int sellInValue, uint quality) 
			: base(sellInValue, quality, new ConcertPassQualityCalculator())
		{
		}

	}
}
