using Moq;
using NUnit.Framework;
using System;
using System.Reflection;
using TirePresureMonitoringSystem;

namespace TyrePressureMonitoringSystemTests
{
    [TestFixture]
    public class TyrePressureMonitoringSystemTests
    {
        [Test]
        public void AlarmOnNoCheckWorksCorrectly()
        {
            Alarm alarm = new Alarm();

            bool expectedResult = false;
            bool actualResult = alarm.AlarmOn;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AlarmOnCheckInRangeWorksCorrectly()
        {
            Mock<ISensor> sensorMock = new Mock<ISensor>();
            sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(19D);

            Alarm alarm = new Alarm(sensorMock.Object);

            alarm.Check();

            bool expectedResult = false;
            bool actualResult = alarm.AlarmOn;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(16.99)]
        [TestCase(21.01)]
        public void AlarmOnCheckOutOfRangeWorksCorrectly(double pressure)
        {
            Mock<ISensor> sensorMock = new Mock<ISensor>();
            sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(pressure);

            Alarm alarm = new Alarm(sensorMock.Object);

            alarm.Check();

            bool expectedResult = true;
            bool actualResult = alarm.AlarmOn;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AlarmOnCheckOutOfRangeThenInRangeStaysOn()
        {
            Mock<ISensor> sensorMock = new Mock<ISensor>();
            sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(25D);

            Alarm alarm = new Alarm(sensorMock.Object);

            alarm.Check();

            sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(20D);

            alarm.Check();

            bool expectedResult = true;
            bool actualResult = alarm.AlarmOn;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
