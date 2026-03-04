using StrategyAndTemplateMethod.Abstraction;

namespace StrategyAndTemplateMethod.Strategies
{
    public class StrategyA : Algorithm
    {
        public override void Step1()
        {
            Console.WriteLine("Executing Step 1 of Strategy A");
        }

        public override void Step2()
        {
            Console.WriteLine("Executing Step 2 of Strategy A");
        }

        public override void Step3()
        {
            Console.WriteLine("Executing Step 3 of Strategy A");
        }
    }
}
