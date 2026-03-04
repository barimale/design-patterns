namespace PrototypeAndCollectingParameter.Factory.Builders.Model
{
    public class Stats: ICloneable
    {
        public int Strength { get; set; } = 0;
        public int Agility { get; set; } = 0;
        public int Intelligence { get; set; } = 0;

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
