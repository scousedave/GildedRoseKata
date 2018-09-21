namespace GildedRose.InventoryManagement.Utility
{
	public static class StringExtensions
	{
		public static string Normalize(this string text)
		{
			return text.Replace(" ", "").ToLower();
		}
	}
}
