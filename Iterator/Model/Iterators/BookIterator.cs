using Iterator.Model;

namespace Iterator.Model.Iterators
{
    public class BookIterator : IIterator<Book>
    {
        private readonly Book[] _books;
        private int _position = 0;

        public BookIterator(Book[] books)
        {
            _books = books;
        }

        public bool HasNext()
        {
            return _position < _books.Length && _books[_position] != null;
        }

        public Book Next()
        {
            return _books[_position++];
        }
    }

}
