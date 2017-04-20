using static System.Math;
using System.Text;
namespace B17_Ex01_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            short[] inputNumbers = new short[3];
            StringBuilder[] binaryNumbers = new StringBuilder[3];

            // Input
            for (int i = 0; i < 3; i++)
            {
                inputNumbers[i] = getNumberFromUser();
            }
            
            // Binary Numbers
            for (int i = 0; i < 3; i++)
            {
                binaryNumbers[i] = convertShortToBinary(inputNumbers[i]);
                System.Console.WriteLine(binaryNumbers[i]);
            }

            printBinaryDigitsStat(binaryNumbers);

            // Monotonic Series
            printMonotonicSeriesStat(inputNumbers);

            // Numbers Average
            System.Console.WriteLine("The Average of the 3 numbers is {0} ", calcNumbersAverage(inputNumbers));
        }

        // Input
        private static short getNumberFromUser()
        {
            bool isValidInput = true;
            string inputNumber;
            short parsedInputNumber = 0;

            do
            {
                string messageToUser = isValidInput ? "please enter a three digit natural number\n" :
                                                      "Error!\nplease enter a valid input\n";
                System.Console.WriteLine(messageToUser);
                inputNumber = System.Console.ReadLine();
                isValidInput = is3DigitNaturalNumber(inputNumber, ref parsedInputNumber);

            } while (!isValidInput);

            return parsedInputNumber;
        }

        private static bool is3DigitNaturalNumber(string i_InputNumber, ref short o_ParsedInputNumber)
        {

            bool isValidInput = false;


            if (short.TryParse(i_InputNumber, out o_ParsedInputNumber))
            {
                isValidInput = o_ParsedInputNumber > 0 && i_InputNumber.Length == 3;
            }

            return isValidInput;
        }

        // Binary Numbers
        private static StringBuilder convertShortToBinary(short i_ShortNumber)
        {       
            StringBuilder calculatedNumber = new StringBuilder();

            while(i_ShortNumber > 0)
            {
                calculatedNumber.Insert(0,(i_ShortNumber % 2).ToString()) ;
                i_ShortNumber = i_ShortNumber /= 2;
            }

            return calculatedNumber;
        }

        private static void printBinaryDigitsStat(StringBuilder[] i_IntputNumbers)
        {
            float numOfZero = 0;
            float numOfOnes = 0;
            float averageNumZero;
            float averageNumOnes;

            foreach (StringBuilder binaryNumber in i_IntputNumbers)
            {
                for (int i = 0; i < binaryNumber.Length; i++)
                {
                    if (binaryNumber[i] == '0')
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
            System.Console.WriteLine("the average number of zeros is: " + averageNumZero + "\nthe average number of ones is: " + averageNumOnes);
        }

        // Monotonic Series
        private static void printMonotonicSeriesStat(short[] i_IntputNumbers)
        {
            short quantityOfInputNumbersFormingAnAscendingSeries = 0;
            short quantityOfInputNumbersFormingADecendingSeries = 0;

            foreach (short number in i_IntputNumbers)
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

            System.Console.WriteLine("The number of input numbers forming an ascending series = " + quantityOfInputNumbersFormingAnAscendingSeries);
            System.Console.WriteLine("The number of input numbers forming an decending series = " + quantityOfInputNumbersFormingADecendingSeries);
        }

        private static bool isAscendingSeries(short i_Number)
        {
            const bool v_CheckIfAscending = true;

            return isMonotonicSeries(i_Number, v_CheckIfAscending);
        }

        private static bool isDescendingSeries(short i_Number)
        {
            const bool v_CheckIfAscending = true;

            return isMonotonicSeries(i_Number, !v_CheckIfAscending);
        }

        private static bool isMonotonicSeries(short i_Number, bool i_CheckIfAscending)
        {
            bool monotonicSeries = true;

            for (int i = 0; i < 2 && monotonicSeries; i++)
            {
                short previousDigit = (short)(i_Number % 10);
                i_Number = (short)(i_Number / 10 - previousDigit / 10);
                short currentDigit = (short)(i_Number % 10);
                monotonicSeries = (i_CheckIfAscending) ? currentDigit < previousDigit :
                                                         currentDigit > previousDigit;
            }

            return monotonicSeries;
        }
        
        // Numbers Average
        private static float calcNumbersAverage(short[] i_Numbers)
        {
            float sum = 0;

            foreach (short number in i_Numbers)
            {
                sum += number;
            }

            return sum / i_Numbers.Length;
        }

    }
}
