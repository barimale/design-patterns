using StrategyAndTemplateMethod.Abstraction;

namespace StrategyAndTemplateMethod.Strategies
{
    public class StrategyB : Algorithm
    {
        public override void Step1()
        {
            Console.WriteLine("Executing Step 1 of Strategy B");
        }

        public override void Step2()
        {
            Console.WriteLine("Executing Step 2 of Strategy B");
        }

        public override void Step3()
        {
            Console.WriteLine("Executing Step 3 of Strategy B");
        }
    }
}
