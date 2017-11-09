using System;

namespace CommandLineApplication
{
    public class Utils
    {

        public virtual void GetUserDates(out string[] dates)
        {
            Console.WriteLine("Please type the first date: ");
            var firstUserInput = Console.ReadLine();

            Console.WriteLine("Please type the second date: ");
            var secondUserInput = Console.ReadLine();

            dates = new[] {firstUserInput, secondUserInput};
        }
    }
}
