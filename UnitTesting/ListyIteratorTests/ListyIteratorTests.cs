using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ListyIteratorTests
{
    [TestFixture]
    public class ListyIteratorTests
    {
        private ListyIterator<string> listIterator;
        private List<string> initializingCollection;

        [SetUp]
        public void TestInit()
        {
             this.initializingCollection = new List<string> { "qwe", "asd", "zxc" };
             this.listIterator = new ListyIterator<string>(this.initializingCollection);
        }

        [Test]
        public void InitializationConstructorCannotWorkWithNull()
        {
            
            Assert.That(() => new ListyIterator<string>(null), Throws.ArgumentException);
        }

        [Test]
        public void MoveReturnsTrueWhenSuccessful()
        {
            Assert.That(() => this.listIterator.Move(), Is.EqualTo(true));
            Assert.That(() => this.listIterator.Move(), Is.EqualTo(true));
        }

        [Test]
        public void MoveReturnsFalseWhenThereIsNoMoreElements()
        {
            
            this.listIterator.Move();
            this.listIterator.Move();

           
            Assert.That(()=>this.listIterator.Move(),Is.EqualTo(false));
        }

        [Test]
        public void MoveMovesTheInternalIndexToTheNextElementInTheCollection()
        {
            
            this.listIterator.Move();
            var internalIndexValue = typeof(ListyIterator<string>)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "currentInternalIndex")
                .GetValue(this.listIterator);

            
            Assert.That(internalIndexValue,Is.EqualTo(1));
        }

        [Test]
        public void HasNextReturnsTrueIfThereIsNextElement()
        {
            
            this.listIterator.Move();

            
            Assert.IsTrue(this.listIterator.HasNext());
        }

        [Test]
        public void HasNextReturnsFalseIfThereIsNotNextElement()
        {
            this.listIterator.Move();
            this.listIterator.Move();

            Assert.IsFalse(this.listIterator.HasNext());
        }

       

        [Test]
        public void CannotPrintWithEmptyIterator()
        {
            
            this.listIterator = new ListyIterator<string>();

            Assert.That(() => this.listIterator.Print(), Throws.ArgumentException);
        }


    }
}
