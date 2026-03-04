using ChainOfResponsabilities;
using ChainOfResponsabilities.Model;

namespace UTs.Executor
{
    public class ChainOfResponsabilitiesAndFacade
    {
        [Fact]
        public async Task Execute()
        {
            // given
            var pipeline = new PipelineFacade();
            pipeline.Initialize();

            // when
            await pipeline.Run(new DummyInput { Data = "Sample data" });

            // then
        }
    }
}
