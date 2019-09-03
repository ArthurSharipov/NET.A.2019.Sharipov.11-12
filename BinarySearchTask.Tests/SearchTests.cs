using NUnit.Framework;
using System;

namespace BinarySearchTask.Tests
{
    public class SearchTests
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 9, 8 }, 8, ExpectedResult = 5)]
        [TestCase(new int[] { int.MaxValue, 986, -598, -1337, 98563 }, int.MaxValue, ExpectedResult = 4)]
        [TestCase(new int[] { int.MaxValue, 986, -598, -1337, 98563, int.MinValue }, int.MinValue, ExpectedResult = 0)]
        public int BinarySearchTest(int[] array, int element)
        {
            Comparison<int> comparison = (x, y) => x.CompareTo(y);

            Search search = new Search();

            return search.BinarySearch<int>(array, element, comparison);
        }
    }
}