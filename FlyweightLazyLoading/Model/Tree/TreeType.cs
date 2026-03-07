namespace FlyweightLazyLoading.Model.Trees
{
    public class TreeType
    {
        public string Name { get; }
        public string Color { get; }
        public string Texture { get; }

        public TreeType(string name, string color, string texture)
        {
            Console.WriteLine($"[INIT] Tworzę TreeType: {name}, {color}, {texture}");
            Name = name;
            Color = color;
            Texture = texture;
        }

        public void Draw(int x, int y)
        {
            Console.WriteLine($"Rysuję drzewo: {Name} ({Color}, {Texture}) na ({x},{y})");
        }
    }

}
