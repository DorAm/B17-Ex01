using System;
using B17_Ex_01_2;

namespace B17_Ex_01_3

{
    class Program
    {
        public static void Main()
        {
            string userInput;

            do
            {
                System.Console.WriteLine("Hello! please enter your clock hight - a positive natural number.");
                userInput = System.Console.ReadLine();
            } while (!checkUserInput(userInput));

            short sandClockHight = short.Parse(userInput);
            sandClockHight = (sandClockHight % 2) == 0 ? (short)(sandClockHight + 1) : (short)(sandClockHight + 0) ;
           
            B17_Ex_01_2.Program.PrintSandClock(sandClockHight);
            
        }

        private static bool checkUserInput(string i_UserInput)
        {
            float testedInput = float.Parse(i_UserInput);
            return testedInput > 0 && (testedInput % 1) == 0;
        }
    }
}
