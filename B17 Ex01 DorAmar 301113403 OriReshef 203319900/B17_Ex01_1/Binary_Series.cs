
namespace B17_Ex01_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            getNumberFromUser();
        }
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
     
    }
    
}
