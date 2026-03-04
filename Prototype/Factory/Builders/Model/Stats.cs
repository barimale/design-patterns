namespace PrototypeAndCollectingParameter.Factory.Builders.Model
{
    public class Stats: ICloneable
    {
        public int Strength { get; set; } = 0;
        public int Agility { get; set; } = 0;
        public int Intelligence { get; set; } = 0;

        internal Stats()
        {
            // intentionally left blank
        }

        public Stats(Stats stats)
        {
            var cloned = (Stats)stats.Clone();

            this.Strength = cloned.Strength;
            this.Intelligence = cloned.Intelligence;
            this.Agility = cloned.Agility;
        }

        public object Clone()
        {
            return new Stats
            {
                Strength = this.Strength,
                Agility = this.Agility,
                Intelligence = this.Intelligence
            };
        }
    }

}
