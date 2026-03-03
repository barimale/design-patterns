namespace Prototype
{
    public class CharacterBuilder
    {
        private readonly Character _character;
        private CharacterBuilder()
        {
            _character = new Character();
        }

        public static CharacterBuilder CreateBuilder()
        {
            return new CharacterBuilder();
        }

        public CharacterBuilder WithName(string name)
        {
            _character.Name = name;
            return this;
        }

        public CharacterBuilder WithStats(Stats stats)
        {
            _character.Stats = stats;
            return this;
        }

        public CharacterBuilder WithInventory(List<Item> inventory)
        {
            _character.Inventory = inventory;
            return this;
        }

        public CharacterBuilder WithSkills(List<string> skills)
        {
            _character.Skills = skills;
            return this;
        }

        public Character Build()
        {
            return new Character(_character);
        }

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
            public List<Item> Inventory { get; set; } = new List<Item>();
            public List<string> Skills { get; set; } = new List<string>(); 

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
}
