using Decorator.Model.Abstraction;

namespace Decorator.Model
{
    public class Coffee : IDrink
    {
        public string GetDescription() => "Kawa";
        public decimal GetCost() => 5.00m;
    }
}
