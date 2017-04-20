using System;
using B17_Ex_01_2;

namespace B17_Ex_01_3
{
    class Program
    {
        public static void Main()
        {
            string userInput;
            short sandClockHeight = 0;

            do
            {
                Console.WriteLine("Hello! please enter your clock height - a positive natural number.");
                userInput = Console.ReadLine();
            } while (!checkUserInput(userInput, ref sandClockHeight));

            sandClockHeight = (sandClockHeight % 2) == 0 ? (short)(sandClockHeight + 1) : (short)(sandClockHeight + 0);

            B17_Ex_01_2.Program.PrintSandClock(sandClockHeight);

        }

        private static bool checkUserInput(string i_UserClockHeightInput, ref short o_SandClockHeight)
        {
            bool isValidInput = false;

            if (short.TryParse(i_UserClockHeightInput, out o_SandClockHeight))
            {
                isValidInput = o_SandClockHeight > 0;
            }

            return isValidInput;
        }
    }
}
