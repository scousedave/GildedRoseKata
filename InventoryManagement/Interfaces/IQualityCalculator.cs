namespace GildedRose.InventoryManagement.Interfaces
{
	public interface IQualityCalculator
	{
		bool CanDegrade { get; }

		uint CalculatNewQuality(int sellInValue, uint quality);
	}
}
