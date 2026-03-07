using Adapter;
using Adapter.Model;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class Adapter : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public Adapter(ITestOutputHelper output)
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
            OldLogger oldLogger = new OldLogger();
            INewLogger logger = new LoggerAdapter(oldLogger);

            // when
            logger.LogInfo("System działa poprawnie");
            logger.LogError("Wystąpił błąd");

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
