using System.Linq;
using GildedRose.InventoryManagement.Interfaces;
using Xunit;

namespace GildedRose.InventoryManagement.XUnitTests
{
	public class StockItemAgingTests
	{
		private static IInventory _inventory;
		public const int MAX_QUALITY = 50;

		public StockItemAgingTests()
		{
			_inventory = new Inventory(MAX_QUALITY);

		}

		[Fact]
		public void CanCreateAgedBrie()
		{
			_inventory.InventoryItems.Clear();
			_inventory.AddStock("Aged Brie", 1, 1);

			var result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Aged Brie".Normalize() && x.SellInValue == 1 && x.Quality == 1);
			Assert.True(result, "Aged Brie 1 1 has been created");

			_inventory.AddDay();

			result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Aged Brie".Normalize() && x.SellInValue == 0 && x.ConstrainedQuality == 2);
			Assert.True(result, "Aged Brie 1 1 has been aged to 0 2");

		}

		[Fact]
		public void CanCreateBackstagePasses()
		{
			_inventory.InventoryItems.Clear();

			_inventory.AddStock("Backstage passes", -1, 2);
			_inventory.AddStock("Backstage passes", 9, 2);

			var result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Backstage passes".Normalize() && x.SellInValue == -1 && x.Quality == 2);
			Assert.True(result, "Backstage passes -1 2 has been created");

			result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Backstage passes".Normalize() && x.SellInValue == 9 && x.Quality == 2);
			Assert.True(result, "Backstage passes 9 2 has been created");

			_inventory.AddDay();

			result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Backstage passes".Normalize() && x.SellInValue == -2 && x.ConstrainedQuality == 0);
			Assert.True(result, "Backstage passes -1 2 has been aged to -2 0");

			result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Backstage passes".Normalize() && x.SellInValue == 8 && x.ConstrainedQuality == 4);
			Assert.True(result, "Backstage passes 9 2 has been aged to 8 4");
		}

		[Fact]
		public void CanCreateSulfuras()
		{
			_inventory.InventoryItems.Clear();
			_inventory.AddStock("Sulfuras", 2, 2);

			var result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Sulfuras".Normalize() && x.SellInValue == 2 && x.Quality == 2);
			Assert.True(result, "Sulfuras 2 2 has been created");

			_inventory.AddDay();

			result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Sulfuras".Normalize() && x.SellInValue == 2 && x.ConstrainedQuality == 2);
			Assert.True(result, "Sulfuras 2 2 has been aged to 2 2");

		}

		[Fact]
		public void CanCreateNormalItem()
		{
			_inventory.InventoryItems.Clear();
			_inventory.AddStock("Normal Item", -1, 55);
			_inventory.AddStock("Normal Item", 2, 2);

			var result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Normal Item".Normalize() && x.SellInValue == -1 && x.Quality == 55);
			Assert.True(result, "Normal Item -1 55 has been created");

			result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Normal Item".Normalize() && x.SellInValue == 2 && x.Quality == 2);
			Assert.True(result, "Normal Item 2 2 has been created");

			_inventory.AddDay();

			result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Normal Item".Normalize() && x.SellInValue == -2 && x.ConstrainedQuality == 50);
			Assert.True(result, "Normal Item -1 55 has been aged to -2 50");

			result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Normal Item".Normalize() && x.SellInValue == 1 && x.ConstrainedQuality == 1);
			Assert.True(result, "Normal Item 2 2 has been aged to 1 1");

		}

		[Fact]
		public void CanCreateInvalidItem()
		{
			_inventory.InventoryItems.Clear();
			_inventory.AddStock("INVALID ITEM", 2, 2);

			var result = _inventory.InventoryItems.Any(x => x.NormalizedName == "NO SUCH ITEM".Normalize());
			Assert.True(result, "INVALID ITEM/NO SUCH ITEM has been created");

			_inventory.AddDay();

			result = _inventory.InventoryItems.Any(x => x.NormalizedName == "NO SUCH ITEM".Normalize());
			Assert.True(result, "INVALID ITEM/NO SUCH ITEM has been aged");
		}

		[Fact]
		public void CanCreateConjured()
		{
			_inventory.InventoryItems.Clear();

			_inventory.AddStock("Conjured", 2, 2);
			_inventory.AddStock("Conjured", -1, 5);

			var result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Conjured".Normalize() && x.SellInValue == 2 && x.Quality == 2);
			Assert.True(result, "Conjured 2 2 has been created");

			result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Conjured".Normalize() && x.SellInValue == -1 && x.Quality == 5);
			Assert.True(result, "Conjured -1 5 has been created");

			_inventory.AddDay();

			result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Conjured".Normalize() && x.SellInValue == 1 && x.ConstrainedQuality == 0);
			Assert.True(result, "Conjured 2 2 has been aged to 1 0");

			result = _inventory.InventoryItems.Any(x => x.NormalizedName == "Conjured".Normalize() && x.SellInValue == -2 && x.ConstrainedQuality == 1);
			Assert.True(result, "Conjured -1 5 has been aged to -2 1");
		}
	}
}
