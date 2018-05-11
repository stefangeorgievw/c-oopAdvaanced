using BubbleSort;
using NUnit.Framework;
using System;

namespace BubbleSortTests
{

    [TestFixture]
    public class BubbleTests
    {
        [Test]
        [TestCase(9, 2, 3, 4, 5, 6, 7, 8, 1)]
        [TestCase(9, 8, 7, 6, 5, 4, 3, 2, 1)]
        public void BubbleCanSortNumbers(params int[] numbersToSort)
        {
            
            var bubble = new Bubble();
            var sortedNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            bubble.Sort(numbersToSort);

            Assert.That(numbersToSort, Is.EqualTo(sortedNumbers));
        }
    }
}
