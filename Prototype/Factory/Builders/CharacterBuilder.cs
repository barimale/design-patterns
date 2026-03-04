using PrototypeAndBuildersAndCollectingParameter.Factory.Builders.Model;

namespace PrototypeAndBuildersAndCollectingParameter.Factory.Builders
{
    public class CharacterBuilder
    {
        private readonly Character _character;
        private CharacterBuilder()
        {
            _character = new Character();
        }

        internal static CharacterBuilder CreateBuilder()
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

        public CharacterBuilder WithInventory(params Item[] inventory)
        {
            _character.Inventory = inventory.ToList();
            return this;
        }

        public CharacterBuilder WithSkills(List<Skill> skills)
        {
            _character.Skills = skills;
            return this;
        }
        public CharacterBuilder WithSkills(params Skill[] skills)
        {
            _character.Skills = skills.ToList();
            return this;
        }

        public Character Build()
        {
            return new Character(_character);
        }
    }
}
