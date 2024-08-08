using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleCalculatorByndyusoft
{
    public interface IToken { }

    public class NumberToken : IToken
    {
        public double Value { get; }
        public NumberToken(double value) => Value = value;
    }

    public class OperatorToken : IToken
    {
        public char Operator { get; }
        public OperatorToken(char op) => Operator = op;
    }
}
