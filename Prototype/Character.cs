namespace Prototype
{
    public class Character : ICloneable
    {
        public string Name { get; set; }
        public Stats Stats { get; set; }
        public List<Item> Inventory { get; set; }
        public List<string> Skills { get; set; }

        public object Clone()
        {
            return new Character
            {
                Name = this.Name,
                Stats = this.Stats.Clone(),
                Inventory = this.Inventory
                    .Select(i => i.Clone())
                    .ToList(),
                Skills = new List<string>(this.Skills)
            };
        }
    }

}
