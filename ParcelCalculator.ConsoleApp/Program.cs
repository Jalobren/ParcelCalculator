using ParcelCalculator.AppLayer;
using System;

namespace ParcelCalculator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Enter Weight in kg: ");
                var weight = Console.ReadLine();
                Console.Write("Enter Height in cm: ");
                var height = Console.ReadLine();
                Console.Write("Enter Width in cm: ");
                var width = Console.ReadLine();
                Console.Write("Enter Depth in cm: ");
                var depth = Console.ReadLine();

                var result = DeliveryCostCalculator.Calculate(weight, height, width, depth);
                if (!string.IsNullOrEmpty(result.Error))
                {
                    Console.WriteLine(result.Error);
                }
                else
                {
                    var cost = result.Cost > 0 ? "$" + result.Cost : "N/A";
                    Console.WriteLine("Category: " + result.Category);
                    Console.WriteLine("Cost: " + cost);
                }

                Console.WriteLine("Press ESC to stop or Enter to Calculate again");
                Console.WriteLine();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
}
