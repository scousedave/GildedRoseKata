using System;
using System.Collections.Generic;
using GildedRose.InventoryManagement.Interfaces;

namespace GildedRose.InventoryManagement
{
	public class Inventory : IInventory
	{
		public static uint MaxQuality { get; private set; }

		public List<IStockItem> InventoryItems { get; set; }

		private readonly IStockItemFactory _stockItemFactory;

		public Inventory(uint maxQuality)
		{
			MaxQuality = maxQuality;
			InventoryItems = new List<IStockItem>();
			_stockItemFactory = new StockItemFactory();
		}

		public void AddStock(string name, int sellInValue, uint quality)
		{
			if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
			var item = _stockItemFactory.Create(name, sellInValue, quality);
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
