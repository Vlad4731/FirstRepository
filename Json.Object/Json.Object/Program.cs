using System;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            var digitPatterns = new IPattern[]
            {
                new Character('0'),
                new Range('1', '9')
            };

            foreach (var pattern in digitPatterns)
            {
                if (pattern.Match(text))
                    Console.WriteLine("Match found");
            }
        }
    }
}