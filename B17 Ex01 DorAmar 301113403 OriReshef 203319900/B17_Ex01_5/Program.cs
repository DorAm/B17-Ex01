
using System;

namespace B17_Ex01_5
{
    class Program
    {
        public static void Main(string[] args)
        {
            short minDigitInNumber = 0, maxDigitInNumber = 0;
            short io_greaterThanFirstDigitCounter = 0, io_smallerThanFirstDigitCounter = 0;


            findMinAndMaxDigit(12345678, ref minDigitInNumber, ref maxDigitInNumber);
            Console.WriteLine("The maximum digit in the given number is " + maxDigitInNumber);
            Console.WriteLine("The minimum digit in the given number is " + minDigitInNumber);

            findNumberOfDigitsGreaterAndSmallerThenFirstDigit(12345678, ref io_greaterThanFirstDigitCounter, ref io_smallerThanFirstDigitCounter);
            Console.WriteLine("The number of digits greater then the first digit is " + io_greaterThanFirstDigitCounter);
            Console.WriteLine("The number of digits smaller then the first digit is " + io_smallerThanFirstDigitCounter);

        }

        public static void findMinAndMaxDigit(int i_NaturalNumber, ref short io_MinDigit, ref short io_MaxDigit)
        {
            io_MinDigit = io_MaxDigit = (short)(i_NaturalNumber % 10);  // init to the first digit
            
            while (i_NaturalNumber > 0)
            {
                short currentDigit = (short)(i_NaturalNumber % 10);
                if (io_MinDigit > currentDigit)
                {
                    io_MinDigit = currentDigit;
                }

                if (io_MaxDigit < currentDigit)
                {
                    io_MaxDigit = currentDigit;
                }

                i_NaturalNumber /= 10;
            }
        }

        public static void findNumberOfDigitsGreaterAndSmallerThenFirstDigit(int i_NaturalNumber, ref short io_greaterThanFirstDigitCounter, ref short io_smallerThanFirstDigitCounter)
        {
            short firstDigit = (short)(i_NaturalNumber % 10);

            while (i_NaturalNumber > 0)
            {
                short currentDigit = (short)(i_NaturalNumber % 10);

                if (currentDigit > firstDigit)
                {
                    io_greaterThanFirstDigitCounter++;
                }
                else if (currentDigit < firstDigit)
                {
                    io_smallerThanFirstDigitCounter++;
                }

                i_NaturalNumber /= 10;
            }
        }
    }
}
