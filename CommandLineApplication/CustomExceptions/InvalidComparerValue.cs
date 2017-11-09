using System;
using System.Threading;

namespace CommandLineApplication.CustomExceptions
{
    class InvalidComparerValue : Exception
    {
        public InvalidComparerValue()
        {
        }

        public InvalidComparerValue(string message) : base(message)
        {
            Console.WriteLine(message);
            Thread.Sleep(2000);
        }
    }
}
