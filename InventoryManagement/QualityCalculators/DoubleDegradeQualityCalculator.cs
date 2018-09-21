using System;

namespace GildedRose.InventoryManagement.QualityCalculators
{
	internal class DoubleDegradeQualityCalculator : QualityCalculatorBase
	{
		private readonly NormalQualityCalculator _normalCalculator = new NormalQualityCalculator();
		public override bool CanDegrade => _normalCalculator.CanDegrade;

		internal override uint CalculateQuality(int sellInValue, uint quality)
		{
			var newQuality = _normalCalculator.CalculateQuality(sellInValue, quality);
			newQuality = _normalCalculator.CalculateQuality(sellInValue, newQuality);
			return newQuality;
		}
	}
}
