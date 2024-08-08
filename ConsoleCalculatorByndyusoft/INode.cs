using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleCalculatorByndyusoft
{
    public interface INode
    {
        double Evaluate();
    }

    public class NumberNode : INode
    {
        private readonly double _value;
        public NumberNode(double value) => _value = value;
        public double Evaluate() => _value;
    }

    public class BinaryOperationNode : INode
    {
        private readonly INode _left;
        private readonly INode _right;
        private readonly Func<double, double, double> _operation;

        public BinaryOperationNode(INode left, INode right, Func<double, double, double> operation)
        {
            _left = left;
            _right = right;
            _operation = operation;
        }

        public double Evaluate() => _operation(_left.Evaluate(), _right.Evaluate());
    }
}
