using System;

namespace B17_Ex01_4
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] palindromeStrings = { "abgdseesdgba", "racecar", "racccar", "aba", "אבא", "פרשנו רעבתנ שבדבש נתבער ונשרפ", "ag1234554321ga", "a", "" };
            string[] nonPalindromeStrings = { "abgds3esdgba", "3859jsarlk48ila", "adffde", "adfgda", "rascar", "LoremIpsum" };

            testFunction(isPalindrome, palindromeStrings, nonPalindromeStrings);

            string[] numberStrings = { "891204", "124", "5981205", "0", "", "909090", "767767" };
            string[] nonNumberStrings = { "racecar", "Hello! 5125", "521990H", "8989a5215", "890$89", "@!%^!@", "0x89" };

            testFunction(isNumber, numberStrings, nonNumberStrings);
            //isPalindromeTests();
            //isNumber("abc");
        }

        public static bool isNumber(string i_String)
        {
            bool givenStringIsANumber = true;

            foreach (char character in i_String)
            {
                givenStringIsANumber &= ('0' <= character && character <= '9');
            }

            return givenStringIsANumber;
        }

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
            else {
                result = isPalindrome(i_string.Substring(1, i_string.Length - 2));
            }

            return result;
        }

        //public static bool isPalindromeTests()
        //{
        //    bool allTestsPassed = true;
        //    string messageToUser = "";
        //    string[] palindromeStrings = { "abgdseesdgba", "racecar", "racccar", "aba", "אבא", "פרשנו רעבתנ שבדבש נתבער ונשרפ", "ag1234554321ga", "a", "" };
        //    string[] nonPalindromeStrings = { "abgds3esdgba", "3859jsarlk48ila", "adffde", "adfgda", "rascar", "LoremIpsum" };

        //    foreach (string str in palindromeStrings)
        //    {
        //        bool isCurrStrAPalindrome = isPalindrome(str);
        //        Console.WriteLine("Expected True. Got: " + isCurrStrAPalindrome);
        //        allTestsPassed &= isCurrStrAPalindrome;
        //    }

        //    foreach (string str in nonPalindromeStrings)
        //    {
        //        bool isCurrStrAPalindrome = isPalindrome(str);
        //        Console.WriteLine("Expected False. Got: " + isCurrStrAPalindrome);
        //        allTestsPassed &= !isCurrStrAPalindrome;
        //    }

        //    messageToUser = allTestsPassed ? "All tests passed successfully" : "Some tests failed";
        //    Console.WriteLine("\n" + messageToUser);

        //    return allTestsPassed;
        //}

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
