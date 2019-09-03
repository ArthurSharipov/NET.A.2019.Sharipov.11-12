using BookTask.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookTask.Books
{
    class BookListStorage
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        public BookListStorage(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Reads books from a file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Book> GetBookList(string path)
        {
            List<Book> books = new List<Book>();
            using (var binaryReader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate,
                FileAccess.Read, FileShare.Read)))
            {
                while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                {
                    var book = Reader(binaryReader);
                    books.Add(book);
                }
            }

            _logger.Debug("Get book list.");

            return books;
        }

        /// <summary>
        /// Reader.
        /// </summary>
        /// <param name="binaryReader"></param>
        /// <returns></returns>
        private static Book Reader(BinaryReader binaryReader)
        {
            var isbn = binaryReader.ReadString();
            string author = binaryReader.ReadString();
            var title = binaryReader.ReadString();
            var publishingHouse = binaryReader.ReadString();
            var theYearOfPublishing = binaryReader.ReadInt32();
            var numbersOfPage = binaryReader.ReadInt32();
            var price = binaryReader.ReadDouble();

            return new Book(isbn, author, title, publishingHouse, theYearOfPublishing, numbersOfPage, price);
        }

        /// <summary>
        /// Writes books from a file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="books"></param>
        public void SaveBooks(string path, IEnumerable<Book> books)
        {
            using (var binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create,
                FileAccess.Write, FileShare.None)))
            {
                foreach (var book in books)
                {
                    Writer(binaryWriter, book);
                }
            }

            _logger.Debug("Save books to file.");
        }

        /// <summary>
        /// Writer.
        /// </summary>
        /// <param name="binaryWriter"></param>
        /// <param name="book"></param>
        private static void Writer(BinaryWriter binaryWriter, Book book)
        {
            binaryWriter.Write(book.ISBN);
            binaryWriter.Write(book.Author);
            binaryWriter.Write(book.Title);
            binaryWriter.Write(book.PublishingHouse);
            binaryWriter.Write(book.TheYearOfPublishing);
            binaryWriter.Write(book.NumbersOfPage);
            binaryWriter.Write(book.Price);
        }
    }
}