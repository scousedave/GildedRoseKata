namespace GildedRose.InventoryManagement.Interfaces
{
	public interface IStockItem
	{
		string Name { get; }
		string NormalizedName { get; }
		int SellInValue { get; set; }
		uint Quality { get; set; }
		uint ConstrainedQuality { get; }
		bool CanDegradeByDate { get; }

		IQualityCalculator QualityCalculator { get; }

	}
}
