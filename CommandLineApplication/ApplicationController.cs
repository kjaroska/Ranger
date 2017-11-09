using System;
using System.Collections.Generic;

namespace CommandLineApplication
{
    class ApplicationController
    {
        private readonly DateRanger _dateRanger;

        public ApplicationController(IReadOnlyList<string> args)
        {
            try
            {
                var dateRangerFactory = new DateRangerFactory(new Utils());
                _dateRanger = args.Count == 2 ? dateRangerFactory.GetRanger(args) : dateRangerFactory.GetRanger();
            }
            catch (Exception e)
            {
                Environment.Exit(1);
            }
        }

        public void Run()
        {
            _dateRanger.PrintRange();

        }
    }
}
