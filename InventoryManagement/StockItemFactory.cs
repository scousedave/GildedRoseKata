using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.InventoryManagement.Interfaces;
using GildedRose.InventoryManagement.StockItems;

namespace GildedRose.InventoryManagement
{
	public class StockItemFactory : IStockItemFactory
	{
		private readonly Dictionary<string, Type> _stockItemTypes;

		public StockItemFactory()
		{
			var stockTypes = getAllStockItemTypes();
			_stockItemTypes = new Dictionary<string, Type>(stockTypes.Length);

			foreach (Type stockType in stockTypes)
			{
				IStockItem instantiatedStockType = getStockItem(stockType, 0, 0);
				_stockItemTypes.Add(instantiatedStockType.NormalizedName, stockType);
			}
		}

		public IStockItem Create(string itemName, int sellInValue, uint quality)
		{
			string key = itemName.Normalize();
			if(!_stockItemTypes.ContainsKey(key)) return new UnknownItem(sellInValue, quality);
			IStockItem instantiatedStockType = getStockItem(_stockItemTypes[key], sellInValue, quality);
			return instantiatedStockType;
		}

		private Type[] getAllStockItemTypes()
		{
			return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
				.Where(x => typeof(IStockItem).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToArray();
		}

		private IStockItem getStockItem(Type stockItemType, int sellInValue, uint quality)
		{
			IStockItem instantiatedStockType = (IStockItem)Activator.CreateInstance(stockItemType,
				System.Reflection.BindingFlags.Public |
				System.Reflection.BindingFlags.Instance,
				null, new object[] { sellInValue, quality }, null);
			return instantiatedStockType;
		}
	}
}
