namespace ProxyProperties
{
    public class Property<T> where T : new()
    {
        private T value;
        private readonly string name;

        public Property() : this(default(T)) 
        { 
            // intentionally left blank
        }

        public Property(T value, string name = "")
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
                Console.WriteLine($"SAVE TO DB");
                Console.WriteLine($"Setting value of property {name} to: {value}");
                this.value = value;
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
    }
}
