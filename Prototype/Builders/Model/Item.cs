namespace PrototypeAndCollectingParameter.Builders.Model
{
    public class Item: ICloneable
    {
        public string Name { get; set; } = string.Empty;
        public int Power { get; set; } = 0;

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
