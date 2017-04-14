
using System;

namespace B17_Ex01_5
{
    class Program
    {
        public static void Main(string[] args)
        {
            short minDigitInNumber = 0, maxDigitInNumber = 0;
            short io_greaterThanFirstDigitCounter = 0, io_smallerThanFirstDigitCounter = 0;

            int inputNumber = getNumberFromUser();

            findMinAndMaxDigit(inputNumber, ref minDigitInNumber, ref maxDigitInNumber);
            Console.WriteLine("The maximum digit in the given number is " + maxDigitInNumber);
            Console.WriteLine("The minimum digit in the given number is " + minDigitInNumber);

            findNumberOfDigitsGreaterAndSmallerThenFirstDigit(inputNumber, ref io_greaterThanFirstDigitCounter, ref io_smallerThanFirstDigitCounter);
            Console.WriteLine("The number of digits greater then the first digit is " + io_greaterThanFirstDigitCounter);
            Console.WriteLine("The number of digits smaller then the first digit is " + io_smallerThanFirstDigitCounter);

        }

        private static int getNumberFromUser()
        {
            bool isValidInput = true;
            int inputNumber;

            do
            {
                string messageToUser = isValidInput ? "please enter an eight digit natural number" :
                                                      "Error! Please enter a valid input\n";
                System.Console.WriteLine(messageToUser);

                inputNumber = int.Parse(System.Console.ReadLine());
                isValidInput = is8DigitNaturalNumber(inputNumber);
            } while (!isValidInput);

            return inputNumber;
        }

        private static bool is8DigitNaturalNumber(float i_InputNumber)
        {

            return (10000000 <= i_InputNumber && i_InputNumber <= 99999999) &&
                (i_InputNumber % 1 == 0);
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
