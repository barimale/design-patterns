using ProxyPropertiesWithObserver.PropertySettings.Abstraction;

namespace ProxyPropertiesWithObserver.PropertySettings
{
    public static class PropertyProvider
    {
        public static Property<T> CreateProperty<T>(T initialValue, string name)
        {
            return new Property<T>(initialValue, name);
        }
    }
}
