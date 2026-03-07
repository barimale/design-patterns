namespace ProxyPropertiesWithObserver.PropertySettings.Abstraction
{
    public class Property<T>
    {
        private T value;
        private readonly string name;
        public event EventHandler<T> StateChanged;

        internal Property() : this(default, string.Empty) 
        { 
            // intentionally left blank
        }

        internal Property(T value, string name = "")
        {
            this.name = name;
            this.Value = value;
        }

        public T Value
        {
            get
            {
                Console.WriteLine($"Getting value of property {name}: {value}");
                return value;
            }
            set
            {
                Console.WriteLine($"Setting value of property {name} to: {value}");
                this.value = value;
                OnStateChanged(value);
            }
        }

        public static implicit operator T(Property<T> property)
        {
            return property.Value;
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value);
        }

        protected virtual void OnStateChanged(T newValue)
        {
            StateChanged?.Invoke(this, newValue);
        }
    }
}
