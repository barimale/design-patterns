using ProxyProperties.Properties;
using ProxyProperties.Properties.Abstraction;

namespace ProxyProperties.Model
{
    public class Creature
    {
        public Property<int> agility = PropertyProvider.CreateProperty(0, "Agility");
        public Property<int> inteligence = PropertyProvider.CreateProperty(0, "Inteligence");

        public int Agility
        {
            get { return agility.Value; }
            set { agility.Value = value; }
        }

        public int Inteligence
        {
            get { return inteligence.Value; }
            set { inteligence.Value = value; }
        }
    }
}
