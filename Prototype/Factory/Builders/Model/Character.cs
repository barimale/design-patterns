namespace PrototypeAndCollectingParameter.Factory.Builders.Model
{
        public class Character : ICloneable
        {
            internal Character()
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

            public string Name { get; set; } = string.Empty;
            public Stats Stats { get; set; } = new Stats();
            public List<Item> Inventory { get; set; } = [];
            public List<Skill> Skills { get; set; } = []; 

            public object Clone()
            {
                return new Character
                {
                    Name = this.Name,
                    Stats = (Stats)this.Stats.Clone(),
                    Inventory = this.Inventory
                        .Select(i => (Item)i.Clone())
                        .ToList(),
                    Skills = this.Skills
                        .Select(i => (Skill)i.Clone())
                        .ToList(),
                };
            }
        }
    }
