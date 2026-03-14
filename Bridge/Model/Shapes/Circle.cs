using Bridge.Abstraction;

namespace Bridge.Model.Shapes
{
    public class Circle : Shape
    {
        public Circle(IColor color) : base(color) { }

        public override void Draw()
        {
            Console.WriteLine($"Rysuję okrąg w kolorze: {color.ApplyColor()}");
        }
    }
}
