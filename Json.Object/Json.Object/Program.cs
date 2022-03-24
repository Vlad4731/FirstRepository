using System;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Range interval = new Range('a', 'f');
            Character x = new Character('x');
            Console.WriteLine(interval.Match(""));
            Console.WriteLine(x.Match("xAtraxes"));

            var digitPatterns = new IPattern[]
            {
                new Character('0'),
                new Range('1', '9')
            };

            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            foreach (var pattern in digitPatterns)
            {
                if (pattern.Match(text))
                    System.Console.WriteLine("Match found");
            }
        }
    }
}