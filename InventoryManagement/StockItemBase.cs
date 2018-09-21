using GildedRose.InventoryManagement.Interfaces;

namespace GildedRose.InventoryManagement
{

	public abstract class StockItemBase : IStockItem
	{
		public abstract string Name { get;  }
		public string NormalizedName => Name.Normalize();
		public int SellInValue { get; set; }

		public uint ConstrainedQuality => Quality > Inventory.MaxQuality ? Inventory.MaxQuality : Quality;

		public uint Quality { get; set; }

		public virtual bool CanDegradeByDate => true;

		public IQualityCalculator QualityCalculator { get; }


		protected StockItemBase(int sellInValue, uint quality, IQualityCalculator qualityCalculator)
		{
			SellInValue = sellInValue;
			Quality = quality;
			QualityCalculator = qualityCalculator;
		}

		public override string ToString()
		{
			return $"{Name} {SellInValue} {ConstrainedQuality}";
		}
	}
}
