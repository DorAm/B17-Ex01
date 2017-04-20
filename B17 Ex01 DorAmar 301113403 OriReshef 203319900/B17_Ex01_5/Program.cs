
using System;

namespace B17_Ex01_5
{
    class Program
    {
        public static void Main(string[] args)
        {
            ushort minDigitInNumber = 0, maxDigitInNumber = 0;
            ushort io_greaterThanFirstDigitCounter = 0, io_smallerThanFirstDigitCounter = 0;

            uint inputNumber = getNumberFromUser();

            findMinAndMaxDigit(inputNumber, ref minDigitInNumber, ref maxDigitInNumber);
            Console.WriteLine("The maximum digit in the given number is {0} ", maxDigitInNumber);
            Console.WriteLine("The minimum digit in the given number is {0} ", minDigitInNumber);

            findNumberOfDigitsGreaterAndSmallerThenFirstDigit(inputNumber, ref io_greaterThanFirstDigitCounter, ref io_smallerThanFirstDigitCounter);
            Console.WriteLine("The number of digits greater then the first digit is {0} ", io_greaterThanFirstDigitCounter);
            Console.WriteLine("The number of digits smaller then the first digit is {0} ", io_smallerThanFirstDigitCounter);

            Console.WriteLine("press enter for exit!!!");
            Console.ReadLine();
        }

        private static uint getNumberFromUser()
        {
            bool isValidInput = true;
            string inputNumber;
            uint parsedNumber = 0;

            do
            {
                string messageToUser = isValidInput ? "please enter an eight digit natural number" :
                                                      "Error! Please enter a valid input\n";
                System.Console.WriteLine(messageToUser);

                inputNumber = System.Console.ReadLine();
                isValidInput = is8DigitNaturalNumber(inputNumber, ref parsedNumber);
            } while (!isValidInput);

            return parsedNumber;
        }

        private static bool is8DigitNaturalNumber(string i_InputNumber, ref uint o_ParsedInputNumber)
        {

            bool isValidInput = false;
           
            if (uint.TryParse(i_InputNumber, out o_ParsedInputNumber))
            {
                isValidInput =  i_InputNumber.Length == 8;
            }

            return isValidInput;
        }

        public static void findMinAndMaxDigit(uint i_NaturalNumber, ref ushort io_MinDigit, ref ushort io_MaxDigit)
        {
            io_MinDigit = io_MaxDigit = (ushort)(i_NaturalNumber % 10);  // init to the first digit
            
            while (i_NaturalNumber > 0)
            {
                ushort currentDigit = (ushort)(i_NaturalNumber % 10);
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

        public static void findNumberOfDigitsGreaterAndSmallerThenFirstDigit(uint i_NaturalNumber, ref ushort io_greaterThanFirstDigitCounter, ref ushort io_smallerThanFirstDigitCounter)
        {
            ushort firstDigit = (ushort)(i_NaturalNumber % 10);

            while (i_NaturalNumber > 0)
            {
                ushort currentDigit = (ushort)(i_NaturalNumber % 10);

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
