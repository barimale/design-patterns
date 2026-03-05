using ChainOfResponsabilitiesAndFacade;
using ChainOfResponsabilitiesAndFacade.Model;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class ChainOfResponsabilitiesAndFacade: PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public ChainOfResponsabilitiesAndFacade(ITestOutputHelper output)
            : base(output)
        {
            _originalOut = Console.Out; 
            _redirectWriter = new TestOutputTextWriter(output); 
            Console.SetOut(_redirectWriter);
        }

        [Fact]
        public async Task Execute()
        {
            // given
            var pipeline = new PipelineFacade();
            pipeline.Initialize();

            // when
            await pipeline.Run(new DummyInput { Data = "Sample data" });

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
