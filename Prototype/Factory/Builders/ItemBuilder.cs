using PrototypeAndBuildersAndCollectingParameter.Factory.Builders.Model;

namespace PrototypeAndBuildersAndCollectingParameter.Factory.Builders
{
    public class ItemBuilder
    {
        private readonly Item _item;
        private ItemBuilder()
        {
            _item = new Item();
        }

        internal static ItemBuilder CreateBuilder()
        {
            return new ItemBuilder();
        }

        public ItemBuilder WithName(string name)
        {
            _item.Name = name;
            return this;
        }

        public ItemBuilder WithPower(int power)
        {
            _item.Power = power;
            return this;
        }

        public Item Build()
        {
            return new Item(_item);
        }
    }
}
