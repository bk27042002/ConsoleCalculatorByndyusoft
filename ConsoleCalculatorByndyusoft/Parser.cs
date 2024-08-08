using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleCalculatorByndyusoft
{
    public class ParseException : Exception
    {
        public ParseException(string message) : base(message) { }
    }

    public class Parser
    {
        private readonly List<IToken> _tokens;
        private int _position;

        public Parser(List<IToken> tokens)
        {
            _tokens = tokens;
            _position = 0;
        }

        public INode Parse()
        {
            var expression = ParseExpression();
            if (_position < _tokens.Count)
            {
                throw new ParseException("Неожиданные символы в конце выражения");
            }
            return expression;
        }

        private INode ParseExpression()
        {
            var left = ParseTerm();
            while (Match('+', '-'))
            {
                char op = ((OperatorToken)_tokens[_position - 1]).Operator;
                var right = ParseTerm();
                left = new BinaryOperationNode(left, right, op == '+' ? (a, b) => a + b : (a, b) => a - b);
            }
            return left;
        }

        private INode ParseTerm()
        {
            var left = ParseFactor();
            while (Match('*', '/'))
            {
                char op = ((OperatorToken)_tokens[_position - 1]).Operator;
                var right = ParseFactor();
                left = new BinaryOperationNode(left, right, op == '*' ? (a, b) => a * b : (a, b) => a / b);
            }
            return left;
        }

        private INode ParseFactor()
        {
            if (Match('('))
            {
                var expression = ParseExpression();
                if (!Match(')'))
                {
                    throw new ParseException("Отсутствующая закрывающая скобка");
                }
                return expression;
            }
            if (Match(out NumberToken numberToken))
            {
                return new NumberNode(numberToken.Value);
            }
            throw new ParseException("Неожиданный символ");
        }

        private bool Match(params char[] expected)
        {
            if (_position < _tokens.Count && _tokens[_position] is OperatorToken opToken && Array.Exists(expected, e => e == opToken.Operator))
            {
                _position++;
                return true;
            }
            return false;
        }

        private bool Match(out NumberToken numberToken)
        {
            if (_position < _tokens.Count && _tokens[_position] is NumberToken numToken)
            {
                numberToken = numToken;
                _position++;
                return true;
            }
            numberToken = null;
            return false;
        }
    }
}
