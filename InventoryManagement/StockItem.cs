using GildedRose.InventoryManagement.Interfaces;

namespace GildedRose.InventoryManagement
{

	public class StockItem : IStockItem
	{
		public string Name { get;  }
		public string NormalizedName => Name.Normalize();
		public int SellInValue { get; set; }

		public uint ConstrainedQuality => Quality > Inventory.MaxQuality ? Inventory.MaxQuality : Quality;

		public uint Quality { get; set; }

		public bool CanDegradeByDate { get; }
	
		public IQualityCalculator QualityCalculator { get; }


		public StockItem(string name, int sellInValue, uint quality, IQualityCalculator qualityCalculator, bool canDegradeByDate)
		{
			Name  = name.Equals("INVALID ITEM") ? "NO SUCH ITEM" : name;
			SellInValue = sellInValue;
			Quality = quality;
			QualityCalculator = qualityCalculator;
			CanDegradeByDate = canDegradeByDate;
		}

		public override string ToString()
		{
			if (Name.Equals("NO SUCH ITEM")) return Name;
			return $"{Name} {SellInValue} {ConstrainedQuality}";
		}
	}
}
