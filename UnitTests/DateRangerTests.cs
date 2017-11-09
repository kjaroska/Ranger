using System;
using NUnit.Framework;
using CommandLineApplication;

namespace UnitTests
{
    [TestFixture]
    public class DateRangerTests
    {
        private DateRanger _dateRanger;


        [Test]
        public void IsRangeProperWhenYearsMonthsAreDifferent()
        {
            //Arrange
            var date1 = new DateTime(2001, 01, 01);
            var date2 = new DateTime(2002, 02, 02);
            const string expectedResult = "01.01.2001 - 02.02.2002";

            //Act
            _dateRanger = new DateRanger(date1, date2);
            var result = _dateRanger.DateRange;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IsRangeProperWhenYearsMonthsAreSame()
        {
            //Arrange
            var date1 = new DateTime(2002, 02, 01);
            var date2 = new DateTime(2002, 02, 08);
            const string expectedResult = "01 - 08.02.2002";

            //Act
            _dateRanger = new DateRanger(date1, date2);
            var result = _dateRanger.DateRange;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IsRangeProperWhenYearsAreSame()
        {
            //Arrange
            var date1 = new DateTime(2002, 11, 01);
            var date2 = new DateTime(2002, 12, 22);
            const string expectedResult = "01.11 - 22.12.2002";

            //Act
            _dateRanger = new DateRanger(date1, date2);
            var result = _dateRanger.DateRange;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IsRangeProperWhenDatesAreSame()
        {
            //Arrange
            var date1 = new DateTime(2002, 11, 22);
            var date2 = new DateTime(2002, 11, 22);
            const string expectedResult = "22.11.2002";

            //Act
            _dateRanger = new DateRanger(date1, date2);
            var result = _dateRanger.DateRange;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IsRangeProperWhenFirstDateLaterThanSecond()
        {
            //Arrange
            var date1 = new DateTime(2012, 11, 22);
            var date2 = new DateTime(2002, 11, 22);
            const string expectedResult = "22.11.2002 - 22.11.2012";

            //Act
            _dateRanger = new DateRanger(date1, date2);
            var result = _dateRanger.DateRange;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IsRangeProperFromArgsParameters()
        {
            //Arrange
            string[] testArgs = {"2012.11.22", "2002.11.22"};
            
            const string expectedResult = "22.11.2002 - 22.11.2012";

            //Act
            _dateRanger = new DateRanger(testArgs);
            var result = _dateRanger.DateRange;


            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
