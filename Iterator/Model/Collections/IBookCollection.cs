using Iterator.Model;
using Iterator.Model.Iterators;

namespace Iterator.Model.Collections
{
    public interface IBookCollection
    {
        IIterator<Book> CreateIterator();
    }

}
