# PackageSorter
Function to sort the packages using the given criteria

Overview
This project implements a function that determines where a package should be dispatched in a robotic automation system based on its dimensions and mass.

```
Function
string Sort(int width, int height, int length, int mass)

Returns string such as:
STANDARD
SPECIAL
REJECTED

Example:
// Basic cases
Console.WriteLine(PackageSorter.Sort(10,10,10,5));      // STANDARD
Console.WriteLine(PackageSorter.Sort(200,10,10,5));     // SPECIAL
Console.WriteLine(PackageSorter.Sort(10,10,10,25));     // SPECIAL
Console.WriteLine(PackageSorter.Sort(200,200,200,25));  // REJECTED

// Edge cases
Console.WriteLine(PackageSorter.Sort(100,100,100,10));   // SPECIAL (volume = 1,000,000)
Console.WriteLine(PackageSorter.Sort(150,10,10,5));      // SPECIAL (dimension = 150)
Console.WriteLine(PackageSorter.Sort(10,150,10,5));      // SPECIAL
Console.WriteLine(PackageSorter.Sort(10,10,150,5));      // SPECIAL
Console.WriteLine(PackageSorter.Sort(10,10,10,20));      // SPECIAL (mass = 20)

// Bulky due to volume
Console.WriteLine(PackageSorter.Sort(100,100,101,5));    // SPECIAL

// Bulky + heavy
Console.WriteLine(PackageSorter.Sort(150,150,150,20));   // REJECTED

// Invalid input
// Console.WriteLine(PackageSorter.Sort(0, 10, 10, 5));   // ArgumentException
// Console.WriteLine(PackageSorter.Sort(10, 0, 10, 5));   // ArgumentException
// Console.WriteLine(PackageSorter.Sort(10, 10, 0, 5));   // ArgumentException
// Console.WriteLine(PackageSorter.Sort(10, 10, 10, 0));   // ArgumentException

```
