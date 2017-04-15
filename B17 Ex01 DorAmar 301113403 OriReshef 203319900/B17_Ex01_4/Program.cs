
// TODO: input validation, tests for average and uppercase

using System;

namespace B17_Ex01_4
{
    class Program
    {
            
        public static void Main(string[] args)
        {

            runTests();

            //Console.WriteLine("The average of 521621 is " + calcAverageOfDigits("521621"));
            //Console.WriteLine("getNumberOfUpperCaseChars = " + getNumberOfUpperCaseChars("AGsySFGsafjlk"));

            //isPalindromeTests();
            //isNumber("abc");
        }

        // Core Functions

        public static bool isPalindrome(string i_string)
        {
            bool result;

            if (i_string.Length <= 1)
            {
                result = true;
            }
            else if (i_string[0] != i_string[i_string.Length - 1])
            {
                result = false;
            }
            else
            {
                result = isPalindrome(i_string.Substring(1, i_string.Length - 2));
            }

            return result;
        }

        public static float calcAverageOfDigits(string i_String)
        {
            float averageOfDigits = 0;
            float sumOfDigits = 0;
            short numberOfDigits = 0;

            if (isNumber(i_String))
            {
                int numberAsInt = int.Parse(i_String);
                while (numberAsInt > 0)
                {
                    short currentDigit = (short)(numberAsInt % 10);
                    numberOfDigits++;
                    sumOfDigits += currentDigit;
                    numberAsInt /= 10;
                }
            }

            else
            {
                Console.WriteLine("Error, invalid number entered");
                averageOfDigits = -1;
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

        public static bool isNumber(string i_String)
        {
            bool givenStringIsANumber = true;

            foreach (char character in i_String)
            {
                givenStringIsANumber &= ('0' <= character && character <= '9');
            }

            return givenStringIsANumber;
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
                
        // Testing

        public static void runTests()
        {

            string[] numberStrings = { "891204", "124", "5981205", "0", "", "909090", "767767" };
            string[] nonNumberStrings = { "racecar", "Hello! 5125", "521990H", "8989a5215", "890$89", "@!%^!@", "0x89" };

            testFunction(isNumber, numberStrings, nonNumberStrings);

            string[] letterStrings = { "jasklf", "HelloWorld", "klasjfklui", "", "a", "aba", "feofs" };
            string[] nonLetterStrings = { "1259", "767767", "saklf8", "!@@^5", "^@(*JDFs*#", "HelloGuys!" };

            testFunction(isLettersString, letterStrings, nonLetterStrings);

            string[] palindromeStrings = { "abgdseesdgba", "racecar", "racccar", "aba", "agga", "agdgfsaasfgdga", "a", "" };
            string[] nonPalindromeStrings = { "abgds3esdgba", "asfgatgjsarlksagila", "adffde", "adfgda", "rascar", "LoremIpsum" };

            testFunction(isPalindrome, palindromeStrings, nonPalindromeStrings);
            
        }

        public static bool testFunction(Func<string, bool> functionToTest, string[] successStrings, string[] failStrings)
        {
            bool allTestsPassed = true;
            string messageToUser = "";

            Console.WriteLine("Testing Function " + functionToTest.Method +"\n");

            foreach (string str in successStrings)
            {
                bool resultForCurrentStr = functionToTest(str);
                Console.WriteLine("Expected True. Got: " + resultForCurrentStr);
                allTestsPassed &= resultForCurrentStr;
            }

            foreach (string str in failStrings)
            {
                bool resultForCurrentStr = functionToTest(str);
                Console.WriteLine("Expected False. Got: " + resultForCurrentStr);
                allTestsPassed &= !resultForCurrentStr;
            }

            messageToUser = allTestsPassed ? "All tests passed successfully" : "Some tests failed";
            Console.WriteLine("\n" + messageToUser);
            Console.WriteLine("------------------------------------------------------------------\n");

            return allTestsPassed;
        }
    }
}
