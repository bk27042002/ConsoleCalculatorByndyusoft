using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleCalculatorByndyusoft
{
    public class Evaluator
    {
        private readonly Parser _parser;

        public Evaluator(Parser parser)
        {
            _parser = parser;
        }

        public double Evaluate()
        {
            var rootNode = _parser.Parse();
            return rootNode.Evaluate();
        }
    }
}
