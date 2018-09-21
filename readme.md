


# GildedRoseKata
## Installation

Create an empty directory

git clone https://github.com/scousedave/GildedRoseKata.git

There are 3 projects. The inventory management system is .net standard 2.0 to give it the widest possible compatibility. The unit tests and the Kata test console app are both .net core 2.1. 

## Execution
To execute, load the solution  "GildedRoseKata.sln" into Visual Studio and press F5 to run the Kata app and use the Visual Studio Test Explorer to run the unit tests

or from the command line:
```
cd InvConsole

dotnet build

dotnet run
```
to then run the unit tests

```
cd ..\InventoryUnitTests

dotnet test
```
## Extending the inventory

Stock items can be added by creating classes that inherit from `StockItemBase` anywhere in the solution, so:

```
public class AgedBrandy : StockItemBase
{
	public override string Name => "Aged Brandy";
	public AgedBrandy(int sellInValue, uint quality) 
		: base(sellInValue, quality, new IncreasingQualityCalculator())
	{
	}
}
```

creates an Aged Brandy that gets better with time. This may then be added  to the inventory with:

```
IInventory inventory = new Inventory(50);
inventory.AddStock("Aged Brandy", 1, 1);
```
To create a stock item with a different Quality modifier create a QualityCalculator:
```
public class SuperFreshForOndeDayQualityCalculator : QualityCalculatorBase
{
	public override bool CanDegrade => true;
	internal override uint CalculateQuality(int sellInValue, uint quality)
	{
		if(sellInValue == 0) return Inventory.MaxQuality;
		return 0;
	}
}
```
Then use it in your StockItem;
```
public class FreshBread : StockItemBase
{
	public override string Name => "Fresh Bread";
	public FreshBread(int sellInValue, uint quality) 
		: base(sellInValue, quality, new SuperFreshForOndeDayQualityCalculator())
	{
	}
}
```
and we have bread that's fresh for one day only.
