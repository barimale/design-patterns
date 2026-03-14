namespace Bridge.Abstraction
{
    public abstract class Shape
    {
        protected IColor color;

        protected Shape(IColor color)
        {
            this.color = color;
        }

        public abstract void Draw();
    }
}
