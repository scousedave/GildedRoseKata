using System;
using GildedRose.InventoryManagement;
using GildedRose.InventoryManagement.Interfaces;

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

				addToInventory("Aged Brie", 1, 1);
				addToInventory("Backstage passes", -1, 2);
				addToInventory("Backstage passes", 9, 2);
				addToInventory("Sulfuras", 2, 2);
				addToInventory("Normal Item", -1, 55);
				addToInventory("Normal Item", 2, 2);
				addToInventory("INVALID ITEM", 2, 2);
				addToInventory("Conjured", 2, 2);
				addToInventory("Conjured", -1, 5);

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

		private static void addToInventory(string name, int sellInValue, uint quality)
		{
			Console.WriteLine($"Adding {name} {sellInValue} {quality}");
			_inventory.AddStock(name, sellInValue, quality);
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
