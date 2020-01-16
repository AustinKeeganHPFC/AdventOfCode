using System;
using System.Configuration;

namespace day4
{
    class SecureContainer
    {
        static void Main(string[] args)
        {
            int rangeLow = 206938;
            int rangeHigh = 679128;

            PasswordPossibilityFinder(rangeLow, rangeHigh);
        }

        static void PasswordPossibilityFinder(int rangeLow, int rangeHigh)
        {
            int possiblePasswords = 0;

            for(int password = rangeLow; password <= rangeHigh; password++)
            {
                // parse the int into an array
                string passwordString = password.ToString();

                bool doubleNumbers = false;
                int blockNumber = -1;
                int doubleNumber = -1;
                bool numberBlock = false;
                bool decrease = false;
                bool newBlock = false;


                for(int i = 0; i < passwordString.Length - 1; i++)
                {
                    
                        int currentNumber = int.Parse(passwordString[i].ToString());
                        int nextNumber = int.Parse(passwordString[i+1].ToString());
                        
                        // Check if the current number is equal to the next number
                        if(currentNumber == nextNumber)
                        {
                            if(doubleNumbers == true && numberBlock == false && currentNumber == doubleNumber)
                            {
                                numberBlock = true;
                                blockNumber = currentNumber;
                                if (!newBlock)
                                {
                                    doubleNumbers = false;
                                }
                            }
                            if (numberBlock == true & nextNumber != blockNumber)
                            {
                                numberBlock = false;
                            }
                            if (doubleNumbers)
                            {
                                if (doubleNumber != currentNumber)
                                {
                                    newBlock = true;
                                }
                            }
                            if (!numberBlock)
                            {
                                doubleNumbers = true;
                                doubleNumber = currentNumber;
                            }
                        }
                    
                        // Check if the current number is greater than or equal to the next number
                        if(currentNumber > nextNumber)
                        {
                            decrease = true;
                        }
                    
                }

                if(doubleNumbers == true && decrease == false)
                {
                    possiblePasswords++;
                }
            }

            Console.WriteLine("Possible Passwords: {0}", possiblePasswords);
        }
    }
}
