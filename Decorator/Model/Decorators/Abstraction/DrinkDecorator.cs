using Decorator.Model.Abstraction;

namespace Decorator.Model.Decorators.Abstraction
{
    public abstract class DrinkDecorator : IDrink
    {
        protected IDrink _drink;

        protected DrinkDecorator(IDrink drink)
        {
            _drink = drink;
        }

        public virtual string GetDescription() => _drink.GetDescription();
        public virtual decimal GetCost() => _drink.GetCost();
    }

}
