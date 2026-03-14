namespace Interpreter.Model.Expressions
{
    public class SubtractExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public SubtractExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public int Interpret() => _left.Interpret() - _right.Interpret();
    }

}
