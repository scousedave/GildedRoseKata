namespace GildedRose.InventoryManagement.QualityCalculators
{
	public class NoActionQualityCalculator : QualityCalculatorBase
	{
		public override bool CanDegrade => false;

		public override uint CalculateQuality(int sellInValue, uint quality)
		{
			return quality;
		}
	}
}
