namespace Prototype
{
    public class Stats
    {
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }

        public Stats Clone()
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
