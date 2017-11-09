using System;
using System.Collections.Generic;
using CommandLineApplication.CustomExceptions;

namespace CommandLineApplication
{
    class DateRangerFactory
    {
        private static DateTime _dateOne;
        private static DateTime _dateTwo;
        private readonly Utils _utils;


        public DateRangerFactory(Utils utils)
        {
            _utils = utils;
        }

        public DateRanger GetRanger()
        {
            _utils.GetUserDates(out var dates);
            ValidateDates(dates[0], dates[1]);
            return new DateRanger(_dateOne, _dateTwo);
        }

        public DateRanger GetRanger(IReadOnlyList<string> args)
        {

            ValidateDates(args[0], args[1]);
            return new DateRanger(args);
        }

        public void ValidateDates(string firstDate, string secondDate)
        {
            var canConvertFirst = CanConvertToDateTime(firstDate, out _dateOne);
            var canConvertSecond = CanConvertToDateTime(secondDate, out _dateTwo);
            
            if (!canConvertFirst || !canConvertSecond)
                throw new InvalidDateFormat("You typed invalid date format. Try again. \nApplication will close in 2 seconds.");
        }

        private static bool CanConvertToDateTime(string userInput, out DateTime date)
        {
            return DateTime.TryParse(userInput, out date);
        }

    }
}
