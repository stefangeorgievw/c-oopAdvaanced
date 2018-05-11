
using Moq;
using NUnit.Framework;
using System;

namespace DataTimeNowTests
{
    public class DateTimeNowTests
    {
        private IDateTime sut;

        [SetUp]
        public void TestInit()
        {
            this.sut = new MyDateTime();
        }

        [Test]
        public void NowShouldReturnCurrentDate()
        {
            var expectedValue = DateTime.Now.Date;

            Assert.AreEqual(expectedValue, this.sut.Now().Date);
        }

        [Test]
        public void AddingADayToTheLastOneOfAMonthShouldResultInTheFirstDayOfTheNextMonth()
        {
            var testDate = new DateTime(2000, 10, 31);
            var expectedDate = new DateTime(2000, 11, 1);

            testDate = testDate.AddDays(1);
            Assert.AreEqual(expectedDate, testDate);
        }

        [Test]
        public void AddingADayInALeapYear()
        {
            var testDate = new DateTime(2008, 2, 28);
            var expectedDate = new DateTime(2008, 2, 29);

            testDate = testDate.AddDays(1);

            Assert.AreEqual(expectedDate, testDate);
        }

        [Test]
        public void AddingADayInANonLeapYear()
        {
            var testDate = new DateTime(2009, 2, 28);
            var expectedDate = new DateTime(2009, 3, 1);

            testDate = testDate.AddDays(1);

            Assert.AreEqual(expectedDate, testDate);
        }
    }
}
