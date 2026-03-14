using Composite;
using State;
using State.Model.Context;
using State.Model.States;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class State : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public State(ITestOutputHelper output)
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
            var player = new PlayerContext(new PausedState());

            player.Play();   // Resuming playback...
            player.Pause();  // Pausing...

            // when

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
