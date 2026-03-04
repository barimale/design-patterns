using PrototypeAndCollectingParameter.Factory.Builders;

namespace PrototypeAndCollectingParameter.Factory
{
    public static class DataFactory
    {
        public static CharacterBuilder CreateCharacterBuilder()
        {
            return CharacterBuilder.CreateBuilder();
        }

        public static ItemBuilder CreateItemBuilder()
        {
            return ItemBuilder.CreateBuilder();
        }

        public static StatsBuilder CreateStatsBuilder()
        {
            return StatsBuilder.CreateBuilder();
        }

        public static SkillBuilder CreateSkillBuilder()
        {
            return SkillBuilder.CreateBuilder();
        }
    }
}
