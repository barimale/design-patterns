using Decorator.Model.Abstraction;
using Decorator.Model.Decorators.Abstraction;

namespace Decorator.Model.Decorators
{
    public class MilkDecorator : DrinkDecorator
    {
        public MilkDecorator(IDrink drink) : base(drink) { }

        public override string GetDescription() => _drink.GetDescription() + ", mleko";
        public override decimal GetCost() => _drink.GetCost() + 1.50m;
    }

}
