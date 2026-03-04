using PrototypeAndBuildersAndCollectingParameter.Factory.Builders.Model;

namespace PrototypeAndBuildersAndCollectingParameter.Services
{
    public class CollectingParameterPatternService
    {
        public void SetNameTo(Character item, string name)
        {
            item.Name = name;
        }

        public void SetStatsTo(Character item, Stats stats)
        {
            item.Stats = stats;
        }

        public void SetInventoryTo(Character item, List<Item> inventory)
        {
            item.Inventory = inventory;
        }

        public void SetSkillsTo(Character item, List<Skill> skills)
        {
            item.Skills = skills;
        }
    }
}
