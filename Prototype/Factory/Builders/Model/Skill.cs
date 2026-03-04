namespace PrototypeAndBuildersAndCollectingParameter.Factory.Builders.Model
{
    public class Skill : ICloneable
    {
        public string Name { get; set; } = string.Empty;
        internal Skill()
        {
            // intentionally left blank
        }

        public Skill(Skill item)
        {
            var cloned = (Skill)item.Clone();

            this.Name = cloned.Name;
        }

        public object Clone()
        {
            return new Skill
            {
                Name = this.Name,
            };
        }
    }

}
