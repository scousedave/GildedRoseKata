using GildedRose.InventoryManagement.QualityCalculators;

namespace GildedRose.InventoryManagement.StockItems
{
	public class Conjured : StockItemBase
	{
		public override string Name => "Conjured";

		public Conjured(int sellInValue, uint quality) 
			: base(sellInValue, quality, new DoubleDegradeQualityCalculator())
		{
		}

	}
}
