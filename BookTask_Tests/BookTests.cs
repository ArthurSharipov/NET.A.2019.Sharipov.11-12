using BookTask.Books;
using NUnit.Framework;
using System;

namespace BookTask.Tests
{
    public class BookTests
    {
        [Test]
        [TestCase("AT", null, ExpectedResult = "Author: Jeffrey Richter, Title: CLR via C#")]
        [TestCase("ATPY", null, ExpectedResult = "Author: Jeffrey Richter, Title: CLR via C#, Publishing House: Microsoft Press, The Year Of Publishing: 2012")]
        [TestCase("ATPYP", null, ExpectedResult = "Author: Jeffrey Richter, Title: CLR via C#, Publishing House: Microsoft Press, Price: 59,99")]
        [TestCase("IATPYP", null, ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Author: Jeffrey Richter, Title: CLR via C#, Publishing House: Microsoft Press, The Year Of Publishing: 2012, Price: 59,99")]
        [TestCase("", null, ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Author: Jeffrey Richter, Title: CLR via C#, Publishing House: Microsoft Press, The Year Of Publishing: 2012, Number of page: 826, Price: 59,99")]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            Book book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            return book.ToString(format, formatProvider);
        }
    }
}