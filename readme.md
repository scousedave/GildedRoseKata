


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
