using System;

namespace CommandLineApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            var application = new ApplicationController(args);
            application.Run();

            Console.ReadKey();
        }
    }
}
