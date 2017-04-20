using System;

namespace B17_Ex01_4
{
    class Program
    {
            
        public static void Main(string[] args)
        {
            string inputString;
            int parsedInput;

            do
            {
                Console.WriteLine("Please enter an 8 character string that is either a number or a letters string, but not both\n");
                inputString = Console.ReadLine();

            } while (!isValidInput(inputString, out parsedInput));


            if (isPalindrome(inputString))
            {
                Console.WriteLine("The given string is a palindrome");
            }

            else
            {
                Console.WriteLine("The given string is not a palindrome");
            }

            if (isNaturalNumber(inputString, out parsedInput))
            {
                Console.WriteLine("The average of digits is {0} ", calcAverageOfDigits(parsedInput));
            }
            else if (isLettersString(inputString))
            {
                Console.WriteLine("The number of uppercase characters is {0} ", getNumberOfUpperCaseChars(inputString));
            }

            //for testing the functions:
            //runTests();
        }

        // Core Functions

        public static bool isPalindrome(string i_String)
        {
            bool result;

            if (i_String.Length <= 1)
            {
                result = true;
            }
            else if (i_String[0] != i_String[i_String.Length - 1])
            {
                result = false;
            }
            else
            {
                result = isPalindrome(i_String.Substring(1, i_String.Length - 2));
            }

            return result;
        }

        public static float calcAverageOfDigits(int i_InputNumber)
        {
            float averageOfDigits = 0;
            float sumOfDigits = 0;
            short numberOfDigits = 0;

            //int numberAsInt = int.Parse(i_String);
            while (i_InputNumber > 0)
            {
                int currentDigit;
                i_InputNumber = Math.DivRem(i_InputNumber, 10, out currentDigit);

                //short currentDigit = (short)(i_InputNumber % 10);
                numberOfDigits++;
                sumOfDigits += currentDigit;
                //i_InputNumber /= 10;
            }

            averageOfDigits = sumOfDigits / numberOfDigits;
            return averageOfDigits;
        }

        public static short getNumberOfUpperCaseChars(string i_String)
        {
            short numberOfUppercaseChars = 0;

            if (isLettersString(i_String))
            {
                foreach (char character in i_String)
                {
                    if ('A' <= character && character <= 'Z')
                    {
                        numberOfUppercaseChars++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Error, invalid letter string entered");
                numberOfUppercaseChars = -1;
            }
            
            return numberOfUppercaseChars;
        }

        // String Validation

        public static bool isValidInput(string i_InputString, out int o_ParsedNumber)
        {
            o_ParsedNumber = 0;
            return i_InputString.Length == 8 && (int.TryParse(i_InputString, out o_ParsedNumber) && o_ParsedNumber > 0 || isLettersString(i_InputString) );
        }

        public static bool isNaturalNumber(string i_InputString, out int o_ParsedNumber)
        {
            return int.TryParse(i_InputString, out o_ParsedNumber) && o_ParsedNumber > 0;
        }

        public static bool isLettersString(string i_String)
        {
            bool givenStringIsALettersString = true;

            foreach (char character in i_String)
            {
                givenStringIsALettersString &= ('a' <= character && character <= 'z') || ('A' <= character && character <= 'Z');
            }

            return givenStringIsALettersString;
        }

        // Testing- not valid at this version

        //public static void runTests()
        //{

        //    string[] numberStrings = { "891204", "124", "5981205", "909090", "767767" };
        //    string[] nonNumberStrings = { "racecar", "Hello! 5125", "521990H", "8989a5215", "890$89", "@!%^!@", "0x89" };

        //    testFunction(isNaturalNumber, numberStrings, nonNumberStrings);

        //    string[] letterStrings = { "jasklf", "HelloWorld", "klasjfklui", "", "a", "aba", "feofs" };
        //    string[] nonLetterStrings = { "1259", "767767", "saklf8", "!@@^5", "^@(*JDFs*#", "HelloGuys!" };

        //    testFunction(isLettersString, letterStrings, nonLetterStrings);

        //    string[] validInput = { "hjgtdbgc", "jnkhikjn", "89786545", "jkdncjsk", "abcddbca", "11111111", "12345678", "10101010" };
        //    string[] nonVaildInput = { "123456", "saklf8", "!@@^5", "^@(*JDFs*#", "Hello%Guys!", "12345$78", "9f9f9f", "", "aba", "aedrf", "qwe234" };

        //    testFunction(isValidInput, validInput, nonVaildInput);

        //    string[] palindromeStrings = { "abgdseesdgba", "racecar", "racccar", "aba", "agga", "agdgfsaasfgdga", "a", "" };
        //    string[] nonPalindromeStrings = { "abgds3esdgba", "asfgatgjsarlksagila", "adffde", "adfgda", "rascar", "LoremIpsum" };

        //    testFunction(isPalindrome, palindromeStrings, nonPalindromeStrings);
        //}

        public static bool testFunction(Func<string, bool> functionToTest, string[] successStrings, string[] failStrings)
        {
            bool allTestsPassed = true;
            string messageToUser = "";

            Console.WriteLine("Testing Function {0} \n", functionToTest.Method);

            foreach (string str in successStrings)
            {
                bool resultForCurrentStr = functionToTest(str);
                Console.WriteLine("Expected True. got: {0} in {1}", resultForCurrentStr, str);

                allTestsPassed &= resultForCurrentStr;
            }

            foreach (string str in failStrings)
            {
                bool resultForCurrentStr = functionToTest(str);
                Console.WriteLine("Expected False. got: {0} in {1}", resultForCurrentStr, str);
                allTestsPassed &= !resultForCurrentStr;
            }

            messageToUser = allTestsPassed ? "All tests passed successfully" : "Some tests failed";
            Console.WriteLine("{0}", messageToUser);
            Console.WriteLine("------------------------------------------------------------------\n");

            return allTestsPassed;
        }
    }
}
