namespace Prototype
{
    public class Character : ICloneable
    {
        public Character()
        {
            // intentionally left blank
        }

        public Character(Character hero) // konsktruktor gleboko kopiujacy 
        {
            var clone = (Character)hero.Clone();

            Name = clone.Name;
            Stats = clone.Stats;
            Inventory = clone.Inventory;
            Skills = clone.Skills;
        }

        public string Name { get; set; }
        public Stats Stats { get; set; }
        public List<Item> Inventory { get; set; }
        public List<string> Skills { get; set; }

        public object Clone()
        {
            return new Character
            {
                Name = this.Name,
                Stats = (Stats)this.Stats.Clone(),
                Inventory = this.Inventory
                    .Select(i => (Item)i.Clone())
                    .ToList(),
                Skills = new List<string>(this.Skills)
            };
        }
    }

}
