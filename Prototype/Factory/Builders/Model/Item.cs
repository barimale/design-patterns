namespace PrototypeAndBuildersAndCollectingParameter.Factory.Builders.Model
{
    public class Item: ICloneable
    {
        public string Name { get; set; } = string.Empty;
        public int Power { get; set; } = 0;
        internal Item()
        {
            // intentionally left blank
        }

        public Item(Item item)
        {
            var cloned = (Item)item.Clone();

            this.Name = cloned.Name;
            this.Power = cloned.Power;
        }

        public object Clone()
        {
            return new Item
            {
                Name = this.Name,
                Power = this.Power
            };
        }
    }

}
