using System;

class Program
{
    static void Main(string[] args)
    {
        // Basic cases
        Console.WriteLine(PackageSorter.Sort(10,10,10,5));      // STANDARD
        Console.WriteLine(PackageSorter.Sort(200,10,10,5));     // SPECIAL
        Console.WriteLine(PackageSorter.Sort(10,10,10,25));     // SPECIAL
        Console.WriteLine(PackageSorter.Sort(200,200,200,25));  // REJECTED

        // Edge cases
        Console.WriteLine(PackageSorter.Sort(100,100,100,10));   // SPECIAL
        Console.WriteLine(PackageSorter.Sort(150,10,10,5));      // SPECIAL
        Console.WriteLine(PackageSorter.Sort(10,150,10,5));      // SPECIAL
        Console.WriteLine(PackageSorter.Sort(10,10,150,5));      // SPECIAL
        Console.WriteLine(PackageSorter.Sort(10,10,10,20));      // SPECIAL

        // Bulky due to volume
        Console.WriteLine(PackageSorter.Sort(100,100,101,5));    // SPECIAL

        // Bulky + heavy
        Console.WriteLine(PackageSorter.Sort(150,150,150,20));   // REJECTED
		
		// Invalid input
        // Console.WriteLine(PackageSorter.Sort(0, 10, 10, 5));   // ArgumentException
		// Console.WriteLine(PackageSorter.Sort(10, 0, 10, 5));   // ArgumentException
		// Console.WriteLine(PackageSorter.Sort(10, 10, 0, 5));   // ArgumentException
		// Console.WriteLine(PackageSorter.Sort(10, 10, 10, 0));   // ArgumentException
    }
}

public static class PackageSorter
{
    private const long VolumeThreshold = 1000000;
    private const int DimensionThreshold = 150;
    private const int MassThreshold = 20;

    public static string Sort(int width, int height, int length, int mass)
    {
        ValidateInputs(width, height, length, mass);

        bool bulky = IsBulky(width, height, length);
        bool heavy = IsHeavy(mass);

        if (bulky && heavy)
            return "REJECTED";

        if (bulky || heavy)
            return "SPECIAL";

        return "STANDARD";
    }

    private static bool IsBulky(int width, int height, int length)
    {
        long volume = (long)width * height * length;

        return volume >= VolumeThreshold ||
               width >= DimensionThreshold ||
               height >= DimensionThreshold ||
               length >= DimensionThreshold;
    }

    private static bool IsHeavy(int mass)
    {
        return mass >= MassThreshold;
    }

    private static void ValidateInputs(int width, int height, int length, int mass)
    {
        if (width <= 0 || height <= 0 || length <= 0 || mass <= 0)
            throw new ArgumentException("All input values must be positive");
    }
}
