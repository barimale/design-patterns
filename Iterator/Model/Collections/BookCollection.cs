using Iterator.Model;
using Iterator.Model.Iterators;

namespace Iterator.Model.Collections
{
    public class BookCollection : IBookCollection
    {
        private readonly Book[] _books;
        private int _index = 0;

        public BookCollection(int size)
        {
            _books = new Book[size];
        }

        public void Add(Book book)
        {
            if (_index < _books.Length)
                _books[_index++] = book;
        }

        public IIterator<Book> CreateIterator()
        {
            return new BookIterator(_books);
        }
    }

}
