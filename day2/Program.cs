using System;
using System.IO;
using System.Linq;

namespace day2
{
    class Intcode
    {
        static void Main(string[] args)
        {
            string code = File.ReadAllText("../../../input.txt");

            //string code = "1,9,10,3,2,3,11,0,99,30,40,50";

            int expectedOutput = 19690720;

            string result = IntCodeIterator(code, expectedOutput);

            Console.WriteLine($"IntCode: {result}");
        }

        static int IntCodeComputer(string code, int noun, int verb)
        {
            int[] intCode = code.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();

            intCode[1] = noun;
            intCode[2] = verb;
            bool stopRunning = false;

            for (int i = 0; i <= intCode.Length && stopRunning == false; i = i + 4)
            {
                switch (intCode[i])
                {
                    case 1:
                        // Addition
                        intCode = Opcode.Calculator("addition", intCode, i + 1, i + 2, i + 3);
                        break;
                    case 2:
                        // Multiplication
                        intCode = Opcode.Calculator("multiplication", intCode, i + 1, i + 2, i + 3);
                        break;
                    case 99:
                        // Stop
                        stopRunning = true;
                        break;
                    default:
                        // Default
                        Console.WriteLine("Default Case");
                        stopRunning = true;
                        break;
                }
            }

            return intCode[0];
        }

        static string IntCodeIterator(string code, int expectedOutput)
        {
            for (int n = 0; n <= 99; n++)
            {
                for (int v = 0; v <= 99; v++)
                {
                    int intCodeResult = IntCodeComputer(code, n, v);

                    if (intCodeResult == expectedOutput)
                    { 
                        return $"Expected Output found! Noun: {n} Verb: {v} Result: {100 * n + v}";
                    }
                }
            }
            return "Expected Output not found :(";
        }

        public class Opcode
        {
            public static int[] Calculator(string operation, int[] intCode, int inputPosition1, int inputPosition2, int outputPosition)
            {
                int intCodePosition1 = intCode[inputPosition1];
                int intCodePosition2 = intCode[inputPosition2];
                int intCodeOutput = intCode[outputPosition];

                int value1 = intCode[intCodePosition1];
                int value2 = intCode[intCodePosition2];

                int result = 0;

                switch(operation)
                {
                    case "addition":
                        result = value1 + value2;
                        break;
                    case "multiplication":
                        result = value1 * value2;
                        break;
                    default:
                        Console.WriteLine($"No operation found for {operation}");
                        break;

                }

                intCode[intCodeOutput] = result;

                return intCode;
            }
        }
    }
}
