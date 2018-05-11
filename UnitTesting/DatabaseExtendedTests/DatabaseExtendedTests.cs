using DatabaseExtended;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DatabaseExtendedTests
{
    [TestFixture]
    public class DatabaseExtendedTests

    {
        [Test]
        public void ValidConstructorTest()
        {
            var firstPerson = new Person("Stefan", 1L);
            var secondPerson = new Person("Ivan", 2L);
            var colectionOfPeople = new List<IPerson>() { firstPerson, secondPerson };

            Database db = new Database(colectionOfPeople);
            var type = typeof(Database);
            var fieldInfo = type.GetField("people", BindingFlags.NonPublic | BindingFlags.Instance);
            var people = (List<IPerson>)fieldInfo.GetValue(db);
            IPerson test1 = people[0];
            IPerson test2 = people[1];

            Assert.That(test1, Is.EqualTo(firstPerson));
            Assert.That(test2, Is.EqualTo(secondPerson));


        }

        [Test]
        public void InvalidConstructorTest()
        {

            Assert.That(() => new Database(null), Throws.InvalidOperationException);
        }

        [Test]
        public void ValidAddTest()
        {
            var person = new Person("Test", 11L);

            Database database = new Database();
            database.Add(person);


            Assert.AreEqual(1, database.Count);
        }

        [Test]
        [TestCase(1L, "1L", 1L, "1L")]
        [TestCase(1L, "1L", 10L, "1L")]
        [TestCase(1L, "1L", 1L, "10L")]
        public void InvalidAddMethodTest(long firstId, string firstUsername, long secondId, string secondUsername)
        {

            var firstPerson = new Person(firstUsername, firstId);
            var secondPerson = new Person(secondUsername, secondId);


            Database database = new Database();
            database.Add(firstPerson);


            Assert.That(() => database.Add(secondPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void ValidRemoveMethodTest()
        {

            Database database = new Database();
            var firstPerson = new Person("First", 1L);
            var secondPerson = new Person("Second", 2L);
            var thirdPerson = new Person("Second", 3L);
            database.Add(firstPerson);
            database.Add(secondPerson);

            database.Remove(thirdPerson);
            database.Remove(firstPerson);

            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void InvalidRemoveMethodTest()
        {
            Database database = new Database();
            var firstPerson = new Person("First", 1L);
            var secondPerson = new Person("Second", 2L);
            database.Add(firstPerson);

            Assert.That(() => database.Remove(secondPerson), Throws.InvalidOperationException);

        }

        [Test]
        public void ValidFindByIdMethodTest()
        {
            Database database = new Database();
            var firstPerson = new Person("First", 1L);
            var secondPerson = new Person("Second", 2L);
            database.Add(firstPerson);
            database.Add(secondPerson);

            Assert.That(() => database.FindById(1L), Is.EqualTo(firstPerson));
        }

        [Test]
        public void InvalidFindByIdMethodTest()
        {
            Database database = new Database();
            var firstPerson = new Person("First", 1L);
            var secondPerson = new Person("Second", 2L);
            database.Add(firstPerson);
            database.Add(secondPerson);

            Assert.That(() => database.FindById(3L),Throws.InvalidOperationException);
        }

        [Test]
        public void ValidFindByUsernameMethodTest()
        {
            Database database = new Database();
            var firstPerson = new Person("First", 1L);
            var secondPerson = new Person("Second", 2L);
            database.Add(firstPerson);
            database.Add(secondPerson);

            Assert.That(() => database.FindByUsername("First"), Is.EqualTo(firstPerson));
        }

        [Test]
        public void InvalidFindByUsernameMethodTest()
        {
            Database database = new Database();
            var firstPerson = new Person("First", 1L);
            var secondPerson = new Person("Second", 2L);
            database.Add(firstPerson);
            database.Add(secondPerson);

            Assert.That(() => database.FindByUsername("Pesho"), Throws.InvalidOperationException);
        }
    }
}
