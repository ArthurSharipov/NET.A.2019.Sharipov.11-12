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

        public BookListService(ILogger logger)
        {
            _logger = logger;
        }

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

        private bool IsContains(Book book)
        {
            foreach (var item in books)
            {
                if (book.Equals(item))
                    return true;
            }

            return false;
        }

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

        public List<Book> GetBooks(string path)
        {
            return bookListStorage.GetBookList(path);
        }

        public void Save(string path)
        {
            bookListStorage.SaveBooks(path, books);
        }

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