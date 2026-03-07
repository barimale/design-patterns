using ProxyProperties.Properties;
using ProxyProperties.Properties.Abstraction;

namespace ProxyProperties.Model
{
    public class Creature
    {
        public Property<int> agility = PropertyProvider.CreateProperty(0, "Agility");
        public Property<string> inteligence = PropertyProvider.CreateProperty("empty", "Inteligence");

        public int Agility
        {
            get { return agility.Value; }
            set { agility.Value = value; }
        }

        public string Inteligence
        {
            get { return inteligence.Value; }
            set { inteligence.Value = value; }
        }
    }
}
