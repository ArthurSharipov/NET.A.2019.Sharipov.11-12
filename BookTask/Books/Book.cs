using System;
using System.Globalization;

namespace BookTask.Books
{
    public class Book : IComparable, IComparable<Book>, IFormattable
    {
        /// <summary>
        /// The default constructor.
        /// </summary>
        public Book()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="author"></param>
        /// <param name="title"></param>
        /// <param name="publishingHouse"></param>
        /// <param name="theYearOfPublishing"></param>
        /// <param name="numbersOfPage"></param>
        /// <param name="price"></param>
        public Book(string isbn, string author, string title, string publishingHouse,
            int theYearOfPublishing, int numbersOfPage, double price)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            PublishingHouse = publishingHouse;
            TheYearOfPublishing = theYearOfPublishing;
            NumbersOfPage = numbersOfPage;
            Price = price;
        }

        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string PublishingHouse { get; set; }
        public int TheYearOfPublishing { get; set; }
        public int NumbersOfPage { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Ovveride equals.
        /// </summary>
        /// <param name="bookObj"></param>
        /// <returns>true or false</returns>
        public override bool Equals(object bookObj)
        {
            if (bookObj == null)
            {
                return false;
            }

            if (bookObj.GetType() == GetType())
            {
                Book book = bookObj as Book;
                return Equals(book);
            }

            return false;
        }

        /// <summary>
        /// Ovveride to string.
        /// </summary>
        /// <returns>String representation of the book.</returns>
        public override string ToString() => $"ISBN 13: {ISBN}, AuthorName: {Author}, " +
            $"Title: {Title}, Publisher: {PublishingHouse}, Year: {TheYearOfPublishing}, " +
            $"Number of pages: {NumbersOfPage}, Price: {Price}";

        public override int GetHashCode() => ISBN.GetHashCode();

        /// <summary>
        /// Compares books on isbn.
        /// </summary>
        /// <param name="book"></param>
        /// <returns>true or false</returns>
        public bool Equals(Book book)
        {
            if (book == null)
                return false;

            return book.ISBN == ISBN;
        }

        /// <summary>
        /// Casts an object to a book.
        /// </summary>
        /// <param name="bookObj"></param>
        /// <returns></returns>
        public int CompareTo(object bookObj)
        {
            if (bookObj == null)
                return 1;

            var book = (Book)bookObj;
            return CompareTo(book);
        }

        /// <summary>
        /// Compares books by title.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int CompareTo(Book book)
        {
            if (book == null)
                return 1;

            return string.Compare(Title, book.Title);
        }

        /// <summary>
        /// Displays a string depending on the format.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            if (string.IsNullOrWhiteSpace(format))
            {
                format = "D";
            }

            switch (format)
            {
                case "AT":
                    return $"Author: {Author}, Title: {Title}";

                case "ATPY":
                    return $"Author: {Author}, Title: {Title}, Publishing House: {PublishingHouse}, " +
                        $"The Year Of Publishing: {TheYearOfPublishing.ToString(formatProvider)}";

                case "IATPYP":
                    return $"ISBN 13: {ISBN}, Author: {Author}, Title: {Title}, Publishing House: {PublishingHouse}, " +
                        $"The Year Of Publishing: {TheYearOfPublishing.ToString(formatProvider)}, " +
                        $"Price: {Price.ToString(formatProvider)}";

                case "ATPYP":
                    return $"Author: {Author}, Title: {Title}, Publishing House: {PublishingHouse}, " +
                        $"Price: {Price.ToString(formatProvider)}";

                case "D":
                    return $"ISBN 13: {ISBN}, Author: {Author}, Title: {Title}, Publishing House: {PublishingHouse}, " +
                        $"The Year Of Publishing: {TheYearOfPublishing.ToString(formatProvider)}, Number of page: {NumbersOfPage.ToString(formatProvider)}, " +
                        $"Price: {Price.ToString(formatProvider)}";

                default:
                    throw new FormatException($"The {format} format string is error.");
            }
        }
    }
}