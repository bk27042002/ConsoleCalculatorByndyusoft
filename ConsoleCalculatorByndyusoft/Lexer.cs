using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleCalculatorByndyusoft
{
    public class Lexer
    {
        public List<IToken> Tokenize(string expression)
        {
            var tokens = new List<IToken>();
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (char.IsDigit(c) || c == '.')
                {
                    string number = ParseNumber(expression, ref i);
                    tokens.Add(new NumberToken(double.Parse(number, CultureInfo.InvariantCulture)));
                }
                else if ("+-*/()".Contains(c))
                {
                    tokens.Add(new OperatorToken(c));
                }
            }
            return tokens;
        }

        private string ParseNumber(string expression, ref int index)
        {
            int start = index;
            while (index < expression.Length && (char.IsDigit(expression[index]) || expression[index] == '.'))
            {
                index++;
            }
            index--;
            return expression.Substring(start, index - start + 1);
        }
    }
}
