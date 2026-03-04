using PrototypeAndBuildersAndCollectingParameter.Factory.Builders.Model;

namespace PrototypeAndBuildersAndCollectingParameter.Factory.Builders
{
    public class StatsBuilder
    {
        private readonly Stats _stats;
        private StatsBuilder()
        {
            _stats = new Stats();
        }

        internal static StatsBuilder CreateBuilder()
        {
            return new StatsBuilder();
        }

        public StatsBuilder WithStrength(int strength)
        {
            _stats.Strength = strength;
            return this;
        }

        public StatsBuilder WithAgility(int agility)
        {
            _stats.Agility = agility;
            return this;
        }

        public StatsBuilder WithIntelligence(int intelligence)
        {
            _stats.Intelligence = intelligence;
            return this;
        }

        public Stats Build()
        {
            return new Stats(_stats);
        }
    }
}
