using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace ConsoleCalculatorByndyusoft
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите выражение:");
            string input = Console.ReadLine();

            try
            {
                var lexer = new Lexer();
                var tokens = lexer.Tokenize(input);

                var parser = new Parser(tokens);
                var evaluator = new Evaluator(parser);

                double result = evaluator.Evaluate();
                Console.WriteLine($"Результат: {result}");
            }
            catch (ParseException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
            }
        }
    }
}