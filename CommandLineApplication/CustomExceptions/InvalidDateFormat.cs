using System;
using System.Threading;

namespace CommandLineApplication.CustomExceptions
{
    class InvalidDateFormat : Exception
    {

        public InvalidDateFormat()
        {
        }

        public InvalidDateFormat(string message) : base(message)
        {
            Console.WriteLine(message);
            Thread.Sleep(2000);
        }
    }
}
