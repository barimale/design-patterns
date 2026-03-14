using Bridge.Abstraction;

namespace Bridge.Model.Shapes
{
    public class Square : Shape
    {
        public Square(IColor color) : base(color) { }

        public override void Draw()
        {
            Console.WriteLine($"Rysuję kwadrat w kolorze: {color.ApplyColor()}");
        }
    }
}
