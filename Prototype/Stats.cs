namespace Prototype
{
    public class Stats: ICloneable
    {
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }

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
