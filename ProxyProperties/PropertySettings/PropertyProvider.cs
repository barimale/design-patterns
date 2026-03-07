using ProxyProperties.PropertySettings.Abstraction;

namespace ProxyProperties.PropertySettings
{
    public static class PropertyProvider
    {
        private static PropertyProviderSettings _settings;
        public static void SetPropertyProviderSettings(PropertyProviderSettings settings)
        {
            _settings = settings;
        }

        public static Property<T> CreateProperty<T>(T initialValue, string name)
        {
            return new Property<T>(initialValue, _settings.ConnectionString, name);
        }
    }
}
