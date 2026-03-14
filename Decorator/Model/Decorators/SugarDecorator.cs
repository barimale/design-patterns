using Decorator.Model.Abstraction;
using Decorator.Model.Decorators.Abstraction;

namespace Decorator.Model.Decorators
{
    public class SugarDecorator : DrinkDecorator
    {
        public SugarDecorator(IDrink drink) : base(drink) { }

        public override string GetDescription() => _drink.GetDescription() + ", cukier";
        public override decimal GetCost() => _drink.GetCost() + 0.50m;
    }

}
