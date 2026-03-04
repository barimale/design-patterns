using Singleton;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class Singleton : PrintToConsoleUTBase
    {
        public Singleton(ITestOutputHelper output)
            : base(output)
        {
            // intentionally left blank
        }

        [Fact]
        public void Execute()
        {
            // given
            var singleton = SingletonPattern.Instance;
            singleton.Data = "Hello, Singleton!";
            Output.WriteLine(singleton.Data);

            // when
            var second = SingletonPattern.Instance;
            Output.WriteLine(second.Data);
            second.Data = "Changed data";

            // then
            Output.WriteLine(second.Data);
            Output.WriteLine(singleton.Data);
        }
    }
}
