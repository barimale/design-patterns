using ProxyPropertiesWithObserver.PropertySettings;
using ProxyPropertiesWithObserver.PropertySettings.Abstraction;

namespace ProxyPropertiesWithObserver.Model
{
    public class Creature
    {
        public readonly Property<int> agility = PropertyProvider.CreateProperty(0, "Agility");
        public readonly Property<string> inteligence = PropertyProvider.CreateProperty("empty", "Inteligence");

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
