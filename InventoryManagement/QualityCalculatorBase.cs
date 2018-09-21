using GildedRose.InventoryManagement.Interfaces;

namespace GildedRose.InventoryManagement
{
	public abstract class QualityCalculatorBase : IQualityCalculator
	{
		public abstract bool CanDegrade { get; }

		internal abstract uint CalculateQuality(int sellInValue, uint quality);

		public uint CalculatNewQuality(int sellInValue, uint quality)
		{
			uint newQuality = CalculateQuality(sellInValue, quality);
			if (CanDegrade && sellInValue < 0)
			{
				newQuality = CalculateQuality(sellInValue, newQuality);
			}

			return newQuality;
		}
	}
}
