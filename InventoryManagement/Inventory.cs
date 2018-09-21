using System;
using System.Collections.Generic;
using GildedRose.InventoryManagement.Interfaces;

namespace GildedRose.InventoryManagement
{
	public class Inventory : IInventory
	{
		public static uint MaxQuality { get; private set; }

		public List<IStockItem> InventoryItems { get; set; }


		public Inventory(uint maxQuality)
		{
			MaxQuality = maxQuality;
			InventoryItems = new List<IStockItem>();
		}

		public void AddStock(string name, int sellInValue, uint quality, IQualityCalculator qualityCalculator, bool canDegradeByDate = true)
		{
			if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
			var item = new StockItem(name, sellInValue, quality, qualityCalculator, canDegradeByDate);
			InventoryItems.Add(item);
		}

		public void AddDay()
		{
			foreach (IStockItem stockItem in InventoryItems)
			{
				if(stockItem.CanDegradeByDate) stockItem.SellInValue--;
				stockItem.Quality = stockItem.QualityCalculator.CalculatNewQuality(stockItem.SellInValue, stockItem.Quality);
			}
		}
	}
}
