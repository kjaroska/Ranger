using System;
using System.Collections.Generic;
using System.Globalization;
using CommandLineApplication.CustomExceptions;

namespace CommandLineApplication
{
    class DateRanger
    {
        private readonly DateTime _dateOne;
        private readonly DateTime _dateTwo;
        public static char DateSeparator { get; }
        public string DateRange { get; private set; }


        static DateRanger()
        {
            DateSeparator = Convert.ToChar(CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator);
        }

        public DateRanger(DateTime dateOne, DateTime dateTwo)
        {
            _dateOne = dateOne;
            _dateTwo = dateTwo;
            CreateRange(CompareDates());
        }

        public DateRanger(IReadOnlyList<string> args)
        {
            _dateOne = Convert.ToDateTime(args[0]);
            _dateTwo = Convert.ToDateTime(args[1]);
            CreateRange(CompareDates());
        }

        private void CreateRange(int dateComparerValue)
        {
            switch (dateComparerValue)
            {
                case -1:
                    CreateRange(_dateOne, _dateTwo);
                    break;
                case 0:
                    DateRange = _dateOne.ToShortDateString();
                    break;
                case 1:
                    const string userNotice = "Dates were swapped. You probably made a mistake because first date was later than the second!";
                    Console.WriteLine(userNotice);
                    CreateRange(_dateTwo, _dateOne);
                    break;
                default:
                    throw new InvalidComparerValue("Couldnt compare dates. \nApplication will close in 2 seconds.");
            } 
        }

        private int CompareDates()
        {
            var dateComparerValue = DateTime.Compare(_dateOne, _dateTwo);
            return dateComparerValue;
        }

        private void CreateRange(DateTime dateFrom, DateTime dateTo)
        {
            var datesHaveEqualYears = dateFrom.Year == dateTo.Year;
            var datesHaveEqualMonths = dateFrom.Month == dateTo.Month;

            if (datesHaveEqualYears && datesHaveEqualMonths)
            {
                var from = dateFrom.ToString("dd");
                DateRange = $"{from} - {dateTo.ToShortDateString()}";
            }
            
            else if (datesHaveEqualYears)
            {
                var from = dateFrom.ToShortDateString()
                    .Replace(dateFrom.ToString("yyyy"), string.Empty)
                    .Trim(DateSeparator);
                DateRange = $"{from} - {dateTo.ToShortDateString()}";
            }

            else
                DateRange = $"{dateFrom.ToShortDateString()} - {dateTo.ToShortDateString()}";
        }

        public void PrintRange()
        {
            Console.WriteLine(DateRange);
            Console.WriteLine("Your current culture data format is: " + CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + "\n");
        }
    }

}
