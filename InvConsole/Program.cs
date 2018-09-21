using System;
using GildedRose.InventoryManagement;
using GildedRose.InventoryManagement.Interfaces;
using GildedRose.InventoryManagement.QualityCalculators;

namespace InvConsole
{
	class Program
	{
		private static IInventory _inventory;
		public const int MAX_QUALITY = 50;

		static void Main(string[] args)
		{
			try
			{
				_inventory = new Inventory(MAX_QUALITY);

				Console.WriteLine("");
				Console.WriteLine("Adding Stock Items");
				Console.WriteLine("");

				addToInventory("Aged Brie", 1, 1, new IncreasingQualityCalculator());
				addToInventory("Backstage passes", -1, 2, new ConcertPassQualityCalculator());
				addToInventory("Backstage passes", 9, 2, new ConcertPassQualityCalculator());
				addToInventory("Sulfuras", 2, 2, new LegendaryQualityCalculator(), false);
				addToInventory("Normal Item", -1, 55, new NormalQualityCalculator());
				addToInventory("Normal Item", 2, 2, new NormalQualityCalculator());
				addToInventory("INVALID ITEM", 2, 2, new NoActionQualityCalculator());
				addToInventory("Conjured", 2, 2, new DoubleDegradeQualityCalculator());
				addToInventory("Conjured", -1, 5, new DoubleDegradeQualityCalculator());

				displayStock();

				Console.WriteLine("");
				Console.WriteLine("Adding a day to inventory");

				_inventory.AddDay();

				displayStock();

			}
			catch (Exception e)
			{
				Console.WriteLine("");
				Console.WriteLine(e);
			}

			Console.WriteLine("");
			Console.WriteLine("Finished, please press any key");

			Console.ReadKey();

		}

		private static void addToInventory(string name, int sellInValue, uint quality, IQualityCalculator qualityCalculator, bool canDegradeByDate = true)
		{
			Console.WriteLine($"Adding {name} {sellInValue} {quality}");
			_inventory.AddStock(name, sellInValue, quality, qualityCalculator, canDegradeByDate);
		}

		private static void displayStock()
		{
			Console.WriteLine("");
			Console.WriteLine("Displaying current stock");
			Console.WriteLine("");
			foreach(IStockItem item in _inventory.InventoryItems)
				Console.WriteLine(item);
		}
	}
}
