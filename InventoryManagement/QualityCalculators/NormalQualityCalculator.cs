namespace GildedRose.InventoryManagement.QualityCalculators
{
	public class NormalQualityCalculator : QualityCalculatorBase
	{
		public override bool CanDegrade => true;

		public override uint CalculateQuality(int sellInValue, uint quality)
		{
			return quality == 0 ? 0 : --quality;
		}
	}
}
