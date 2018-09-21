namespace GildedRose.InventoryManagement.QualityCalculators
{
	internal class NormalQualityCalculator : QualityCalculatorBase
	{
		public override bool CanDegrade => true;

		internal override uint CalculateQuality(int sellInValue, uint quality)
		{
			return quality == 0 ? 0 : --quality;
		}
	}
}
