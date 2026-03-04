using StrategyAndTemplateMethod;
using StrategyAndTemplateMethod.Model;

namespace UTs.Executor
{
    public class StrategyAndTemplateMethod
    {
        [Fact]
        public void Execute()
        {
            // given
            var resolver = new StrategyResolver();

            // when
            resolver.Resolve(StrategyEnum.SIMPLE).Execute();
            resolver.Resolve(StrategyEnum.COMPLEX).Execute();

            // then
        }
    }
}
