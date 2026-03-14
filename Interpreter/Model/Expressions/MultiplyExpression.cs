namespace Interpreter.Model.Expressions
{
    public class MultiplyExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public MultiplyExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public int Interpret() => _left.Interpret() * _right.Interpret();
    }

}
