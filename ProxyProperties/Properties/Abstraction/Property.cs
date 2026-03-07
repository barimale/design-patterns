using System.Runtime.CompilerServices;

namespace ProxyProperties.Properties.Abstraction
{
    public class Property<T> where T : new()
    {
        private T value;
        private readonly string name;
        private static string _connectionString;

        public Property() : this(default(T), string.Empty) 
        { 
            // intentionally left blank
        }

        public Property(T value, string connectionString, string name = "")
        {
            this.name = name;
            this.Value = value;
            _connectionString = connectionString;
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
                Console.WriteLine($"SAVE TO DB" + _connectionString);
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
            return new Property<T>(value, _connectionString);
        }
    }
}
