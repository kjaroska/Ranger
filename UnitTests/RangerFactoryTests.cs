using CommandLineApplication;
using CommandLineApplication.CustomExceptions;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    class RangerFactoryTests
    {
        private DateRangerFactory _dateRangerFactory;
        private Mock<Utils> _mockedUtils;

        [SetUp]
        public void SetUp()
        {
            _mockedUtils = new Mock<Utils>();
            _dateRangerFactory = new DateRangerFactory(_mockedUtils.Object);    
        }

        [Test]
        public void DoesValidateDatesThrowsExceptionWhenDateCantBeParsed()
        {
            //Arrange
            const string invalidDate = "35.36.37";
            const string validDate = "12.12.2001";
            var expectedExceptionType = new InvalidDateFormat().GetType();

            //Assert
            Assert.Throws(expectedExceptionType, () => _dateRangerFactory.ValidateDates(invalidDate, validDate));
        }

        [Test]
        public void DoesGetRangeThrowsExceptionWhenArgsAreInvalid()
        {
            //Arrange
            string[] testArgs = {"11.11.2000", "12.12.2005"};

            //Act
            var dateRanger = _dateRangerFactory.GetRanger(testArgs);

            //Assert
            Assert.IsInstanceOf<DateRanger>(dateRanger);
        }

        [Test]
        public void DoesValidateDatesThrowsExceptionWhenUserInputIsInvalid()
        {
            //Arrange
            string[] dates ={ "11.11.2000", "12.35.2002" };
            var expectedExceptionType = new InvalidDateFormat().GetType();

            _mockedUtils.Setup(x => x.GetUserDates(out dates));
            _mockedUtils.Object.GetUserDates(out dates);

            //Assert
            Assert.Throws(expectedExceptionType, () => _dateRangerFactory.ValidateDates(dates[0], dates[1]));
        }

        [Test]
        public void DoesValidateDatesThrowsExceptionWhenArgsAreNotValid()
        {
            //Arrange
            string[] testArgs = { "11.11.2000", "35.35.2005" };
            var expectedExceptionType = new InvalidDateFormat().GetType();

            //Assert
            Assert.Throws(expectedExceptionType, () => _dateRangerFactory.ValidateDates(testArgs[0], testArgs[1]));
        }
    }
}
