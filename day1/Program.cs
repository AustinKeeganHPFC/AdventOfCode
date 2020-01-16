using System;
using System.IO;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Array allLines = File.ReadAllLines("input.txt");
            int aggregate = 0;

            foreach(string line in allLines)
            {
                int number = Int32.Parse(line);
                int objectFuel = Calculator(number);
                int fuelAggregate = FuelFinder(objectFuel);
                aggregate += (objectFuel + fuelAggregate);
                Console.WriteLine("Aggregate: {0}", aggregate);
            }
        }

        static int FuelFinder(int fuel)
        {
            int fuelAggregate = 0;
            int remainingFuel = fuel;
            
            while (Calculator(remainingFuel) > 0)
            {
                Console.WriteLine("Fuel 1: {0}", remainingFuel);
                remainingFuel = Calculator(remainingFuel);
                if (remainingFuel > 0)
                {
                    fuelAggregate += remainingFuel;
                }
                Console.WriteLine("Fuel 2: {0}", remainingFuel);
                Console.WriteLine("FuelAggregate: {0}", fuelAggregate);
            }
            return fuelAggregate;
        }

        static int Calculator(int mass)
        {
            int result = (mass / 3) - 2;
            return result;
        }
    }
}
