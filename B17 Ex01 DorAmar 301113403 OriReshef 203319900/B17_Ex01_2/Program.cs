using System.Text;

namespace B17_Ex_01_2
{
    public class Program
    {
        public static void Main()
        {
            PrintSandClock(5);
        }

        public static void PrintSandClock(int i_ClockHight)
        {
            StringBuilder mySandClock = new StringBuilder();

            for (int i = 0; i < i_ClockHight / 2; i++) //top half of clock
            {
                addSpacesToClock(mySandClock, i);

                for (int j = 0; j < i_ClockHight - (i * 2); j++)
                {
                    mySandClock.Append("* ");
                }

                mySandClock.Append("\n");
            }

           
            for (int i = i_ClockHight / 2; i >= 0; i--) //bottom half of clock
            {
                addSpacesToClock(mySandClock, i);

                for (int j = 0; j < i_ClockHight - (i * 2); j++)
                {
                    mySandClock.Append("* ");
                }

                mySandClock.Append("\n");
            }

           System.Console.WriteLine(mySandClock.ToString());
        }

        private static void addSpacesToClock(StringBuilder io_SandClock, int i_CurrHight)
        {
            for (int i = 0; i < i_CurrHight; i++)
            {
              io_SandClock.Append("  ");
            }
        }
    }
}
