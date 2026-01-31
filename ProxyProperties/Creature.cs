namespace ProxyProperties
{
    public class Creature
    {
        public Property<int> agility = new Property<int>(10, "Agility");

        public int Agility
        {
            get { return agility.Value; }
            set { agility.Value = value; }
        }
    }
}
