namespace GildedRose.InventoryManagement.QualityCalculators
{
	internal class IncreasingQualityCalculator : QualityCalculatorBase
	{
		public override bool CanDegrade => false;

		internal override uint CalculateQuality(int sellInValue, uint quality)
		{
			return ++quality;
		}
	}
}
