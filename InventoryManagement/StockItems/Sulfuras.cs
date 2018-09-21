using GildedRose.InventoryManagement.QualityCalculators;

namespace GildedRose.InventoryManagement.StockItems
{
	public class Sulfuras : StockItemBase
	{
		public override string Name => "Sulfuras";
		public override bool CanDegradeByDate => false;

		public Sulfuras(int sellInValue, uint quality) 
			: base(sellInValue, quality, new LegendaryQualityCalculator())
		{
		}

	}
}
