using Interpreter.Model.Expressions;

namespace Interpreter.Model.Parsers
{
    public class ExpressionParser
    {
        public IExpression Parse(string input)
        {
            var tokens = input.Split(' ');
            IExpression expression = new NumberExpression(int.Parse(tokens[0]));

            for (int i = 1; i < tokens.Length; i += 2)
            {
                string op = tokens[i];
                int number = int.Parse(tokens[i + 1]);

                if (op == "+")
                {
                    expression = new AddExpression(expression, new NumberExpression(number));
                }
                else if (op == "-")
                {
                    expression = new SubtractExpression(expression, new NumberExpression(number));
                }
            }

            return expression;
        }
    }

}
