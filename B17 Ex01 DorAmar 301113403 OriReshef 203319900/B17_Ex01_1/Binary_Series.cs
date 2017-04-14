using static System.Math;
namespace B17_Ex01_1
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            float[] inputNumbers = new float[3];
            string[] binaryNumbers = new string[3];

            // Input
            for (int i = 0; i < 3; i++)
            {
                inputNumbers[i] = getNumberFromUser();
            }
            
            // Binary Numbers
            for (int i = 0; i < 3; i++)
            {
                binaryNumbers[i] = convertFloatToBinary(inputNumbers[i]);
                System.Console.WriteLine(binaryNumbers[i]);
            }
            printBinaryDigitsStat(binaryNumbers);

            // Monotonic Series
            float quantityOfInputNumbersFormingAnAscendingSeries = 0;
            float quantityOfInputNumbersFormingADecendingSeries = 0;
            foreach (float number in inputNumbers)
            {
                if (isAscendingSeries(number))
                {
                    quantityOfInputNumbersFormingAnAscendingSeries += 1;
                }
                if (isDescendingSeries(number))
                {
                    quantityOfInputNumbersFormingADecendingSeries += 1;
                }

            }
            System.Console.WriteLine("quantityOfInputNumbersFormingAnAscendingSeries = " + quantityOfInputNumbersFormingAnAscendingSeries);
            System.Console.WriteLine("quantityOfInputNumbersFormingADecendingSeries = " + quantityOfInputNumbersFormingADecendingSeries);

            // Numbers Average
            System.Console.WriteLine("The Average is" + calcNumbersAverage(inputNumbers));
        }

        // Input
        private static float getNumberFromUser()
        {
            bool isValidInput = true;
            float inputNumber;
            do
            {
                string messageToUser = isValidInput ? "please enter a three digit natural number\n" :
                                                      "Error!\nplease enter a valid input\n";
                System.Console.WriteLine(messageToUser);

                inputNumber = float.Parse(System.Console.ReadLine());
                isValidInput = is3DigitNaturalNumber(inputNumber);
            } while (!isValidInput);

            return inputNumber;
        }
        private static bool is3DigitNaturalNumber(float i_inputNumber)
        {
            return (100 <= i_inputNumber && i_inputNumber <= 999) &&
                (i_inputNumber % 1 == 0);
        }

        // Binary Numbers
        private static string convertFloatToBinary (float i_floatNumber)
        {
            
            string calculatedNumber = "0";
            while(i_floatNumber>0)
            {
                calculatedNumber = (Floor(i_floatNumber % 2)).ToString() + calculatedNumber ;
                i_floatNumber = (float)Floor(i_floatNumber /= 2);
            }
            calculatedNumber.TrimStart('0');
            return calculatedNumber;
        }
        private static void printBinaryDigitsStat(string[] i_IntputNumbers)
        {
            float numOfZero = 0;
            float numOfOnes = 0;
            float averageNumZero;
            float averageNumOnes;


            for (int i = 0; i < 3; i++)
            {
                foreach (char item in i_IntputNumbers[i])
                {
                    if (item == '0')
                    {
                        numOfZero += 1;
                    }
                    else
                    {
                        numOfOnes += 1;
                    }

                }

            }
            averageNumOnes = numOfOnes / 3;
            averageNumZero = numOfZero / 3;
            System.Console.WriteLine("averageNumZero:" + averageNumZero + "\naverageNumOne:" + averageNumOnes);
        }

        // Monotonic Series
        private static bool isAscendingSeries(float i_number)
        {
            bool checkIfAscending = true;
            return isMonotonicSeries(i_number, checkIfAscending);
        }
        private static bool isDescendingSeries(float i_number)
        {
            bool checkIfAscending = true;
            return isMonotonicSeries(i_number, !checkIfAscending);
        }
        private static bool isMonotonicSeries(float i_number, bool i_checkIfAscending)
        {
            bool monotonicSeries = true;

            for (int i = 0; i < 2 && monotonicSeries; i++)
            {
                float previousDigit = i_number % 10;
                i_number = i_number / 10 - previousDigit / 10;
                float currentDigit = i_number % 10;

                monotonicSeries = (i_checkIfAscending) ? currentDigit < previousDigit :
                                                         currentDigit > previousDigit;
            }

            return monotonicSeries;
        }

        // Numbers Average
        private static float calcNumbersAverage(float[] i_numbers)
        {
            float sum = 0;
            foreach (float number in i_numbers)
            {
                sum += number;
            }
            return sum / i_numbers.Length;
        }






    }

}
