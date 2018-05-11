using Database;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace DatabaseTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ValidConstructorTest()
        {
            int[] arr = new int[] {1,2,3,4};
            Database.Database db = new Database.Database(arr);

            var type = typeof(Database.Database);
            var fieldInfo = type.GetField("data", BindingFlags.NonPublic | BindingFlags.Instance);
            int[] field = (int[])fieldInfo.GetValue(db);
            var testField = field.Take(arr.Length);
            Assert.That(arr, Is.EqualTo(testField));
        }

        [Test]
        public void InvalidConstructorTest()
        {
            int[] arr = new int[17] ;
            Assert.That( () => new Database.Database(arr),Throws.InvalidOperationException);


        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(0)]
        public void ValidAddMethodTest(int value)
        {

            Database.Database db = new Database.Database(new int[] { 1, 2, 3 });
            db.Add(value);
            var type = typeof(Database.Database);
            var fieldInfo = type.GetField("data", BindingFlags.NonPublic | BindingFlags.Instance);
            int[] field = (int[])fieldInfo.GetValue(db);
            Assert.That(field[3], Is.EqualTo(value));

        }

        [Test]
        [TestCase(2)]
        [TestCase(-1)]
        [TestCase(0)]
        public void InvalidAddMethodTest(int value)
        {
            Database.Database db = new Database.Database(new int[16] );

            Assert.That(() => db.Add(value), Throws.InvalidOperationException);

        }

        [Test]
        public void ValidRemoveMethodTest()
        {
            var arr = new int[] { 1, 2, 3, 4 };
            Database.Database db = new Database.Database(arr);
            int result = db.Remove();
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void InvalidRemoveMethodTest()
        {
            Database.Database db = new Database.Database(new int[] { });
            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void ValidFetchMethod()
        {
            var arr = new int[] { 1, 2, 3, 4 };
            Database.Database db = new Database.Database(arr);
            Assert.That(() => db.Fetch(), Is.EquivalentTo(arr));
        }

        [Test]
        public void InvalidFetchMethod()
        {
            var arr = new int[] { };
            Database.Database db = new Database.Database(arr);
            Assert.That(() => db.Fetch(), Throws.InvalidOperationException);
        }
    }
}
