using System;

namespace GildedRose.InventoryManagement.QualityCalculators
{
	public class DoubleDegradeQualityCalculator : QualityCalculatorBase
	{
		private readonly NormalQualityCalculator _normalCalculator = new NormalQualityCalculator();
		public override bool CanDegrade => _normalCalculator.CanDegrade;

		public override uint CalculateQuality(int sellInValue, uint quality)
		{
			var newQuality = _normalCalculator.CalculateQuality(sellInValue, quality);
			newQuality = _normalCalculator.CalculateQuality(sellInValue, newQuality);
			return newQuality;
		}
	}
}
