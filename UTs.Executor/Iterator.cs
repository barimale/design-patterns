using Composite;
using Iterator;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class Iterator : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public Iterator(ITestOutputHelper output)
            : base(output)
        {
            _originalOut = Console.Out;
            _redirectWriter = new TestOutputTextWriter(output);
            Console.SetOut(_redirectWriter);
        }

        [Fact]
        public void Execute()
        {
            // given
            var collection = new BookCollection(2);
            collection.Add(new Book("Wiedźmin"));
            collection.Add(new Book("Hobbit"));

            // when
            var iterator = collection.CreateIterator();

            while (iterator.HasNext())
            {
                var book = iterator.Next();
                Output.WriteLine(book.Title);
            }

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
