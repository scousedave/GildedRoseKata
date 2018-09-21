using GildedRose.InventoryManagement.QualityCalculators;

namespace GildedRose.InventoryManagement.StockItems
{
	public class AgedBrie : StockItemBase
	{
		public override string Name => "Aged Brie";


		public AgedBrie(int sellInValue, uint quality) 
			: base(sellInValue, quality, new IncreasingQualityCalculator())
		{
		}

	}
}
