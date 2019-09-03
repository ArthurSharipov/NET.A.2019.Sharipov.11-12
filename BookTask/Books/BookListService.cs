using BookTask.Logs;
using System;
using System.Collections.Generic;

namespace BookTask.Books
{
    class BookListService
    {
        List<Book> books = new List<Book>();

        BookListStorage bookListStorage = new BookListStorage(new Logger());

        private readonly ILogger _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        public BookListService(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Adds a book to the collection.
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            try
            {
                if (book == null)
                    throw new ArgumentNullException(nameof(book));

            }
            catch (ArgumentNullException exception)
            {
                _logger.Error(exception.Message);
            }

            try
            {
                if (IsContains(book))
                    throw new InvalidOperationException(nameof(book));
            }
            catch (InvalidOperationException exception)
            {
                _logger.Error(exception.Message);
            }

            books.Add(book);

            _logger.Debug("Book successfully added.");
        }

        /// <summary>
        /// Checks the book for availability in the collection.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        private bool IsContains(Book book)
        {
            foreach (var item in books)
            {
                if (book.Equals(item))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Removes a book from the collection.
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBook(Book book)
        {
            try
            {
                if (book == null)
                    throw new ArgumentNullException(nameof(book));

            }
            catch (ArgumentNullException exception)
            {
                _logger.Error(exception.Message);
            }

            try
            {
                if (!IsContains(book))
                    throw new InvalidOperationException(nameof(book));
            }
            catch (InvalidOperationException exception)
            {
                _logger.Error(exception.Message);
            }

            books.Remove(book);

            _logger.Debug("Book successfully removed.");
        }

        /// <summary>
        /// Searches for a book by tag.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Book FindBookByTag(IFinder parameter)
        {
            try
            {
                if (parameter == null)
                    throw new ArgumentNullException(nameof(parameter));
            }
            catch (ArgumentNullException exception)
            {
                _logger.Error(exception.Message);
            }

            return parameter.FindBook();
        }

        /// <summary>
        /// Retrieves books from a file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Book> GetBooks(string path)
        {
            return bookListStorage.GetBookList(path);
        }

        /// <summary>
        /// Saves books to a file.
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            bookListStorage.SaveBooks(path, books);
        }

        /// <summary>
        /// Sorts books.
        /// </summary>
        /// <param name="comparer"></param>
        public void Sort(IComparer<Book> comparer)
        {
            try
            {
                if (comparer == null)
                    throw new ArgumentNullException(nameof(comparer));
            }
            catch (ArgumentNullException exception)
            {
                _logger.Error(exception.Message);
            }

            books.Sort(comparer);
        }
    }
}