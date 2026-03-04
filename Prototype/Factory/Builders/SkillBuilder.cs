using PrototypeAndCollectingParameter.Factory.Builders.Model;

namespace PrototypeAndCollectingParameter.Factory.Builders
{
    public class SkillBuilder
    {
        private readonly Skill _skill;
        private SkillBuilder()
        {
            _skill = new Skill();
        }

        internal static SkillBuilder CreateBuilder()
        {
            return new SkillBuilder();
        }

        public SkillBuilder WithName(string name)
        {
            _skill.Name = name;
            return this;
        }

        public Skill Build()
        {
            return new Skill(_skill);
        }
    }
}
