using StrategyAndTemplateMethod.Abstraction;
using StrategyAndTemplateMethod.Model;
using StrategyAndTemplateMethod.Strategies;

namespace StrategyAndTemplateMethod
{
    public class StrategyResolver
    {
        public Algorithm Resolve(StrategyEnum type)
        {
            switch (type)
            {
                case StrategyEnum.SIMPLE:
                    return new StrategyA();
                case StrategyEnum.COMPLEX:
                    return new StrategyB();
                default:
                    throw new Exception();
            }
        }
    }
}
