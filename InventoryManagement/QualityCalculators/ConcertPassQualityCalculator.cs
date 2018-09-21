﻿namespace GildedRose.InventoryManagement.QualityCalculators
{
	internal class ConcertPassQualityCalculator : QualityCalculatorBase
	{
		public override bool CanDegrade => false;

		internal override uint CalculateQuality(int sellInValue, uint quality)
		{
			if (sellInValue < 0) return 0;
			if (sellInValue <= 5) return quality + 3;
			if (sellInValue <= 10) return quality + 2;
			return quality + 1;
		}
	}
}
