using NUnit.Framework;

namespace GeneratorFibonacci.Tests
{
    public class GeneratorTests
    {
        [Test]
        [TestCase(-15, ExpectedResult = new int[] { 0, -1, -1, -2, -3, -5, -8, -13, -21, -34, -55, -89, -144, -233, -377, -610 })]
        [TestCase(-10, ExpectedResult = new int[] { 0, -1, -1, -2, -3, -5, -8, -13, -21, -34, -55 })]
        [TestCase(-5, ExpectedResult = new int[] { 0, -1, -1, -2, -3, -5 })]
        [TestCase(0, ExpectedResult = new int[] { 0 })]
        [TestCase(5, ExpectedResult = new int[] { 0, 1, 1, 2, 3, 5 })]
        [TestCase(10, ExpectedResult = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 })]
        [TestCase(15, ExpectedResult = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610 })]
        public int[] GeneratorFibonacciTest(int number)
        {
            Generator generator = new Generator();

            return generator.GeneratorFibonacci(number);
        }
    }
}