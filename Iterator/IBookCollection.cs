namespace Iterator
{
    public interface IBookCollection
    {
        IIterator<Book> CreateIterator();
    }

}
