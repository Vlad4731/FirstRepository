using System;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {
            Range interval = new Range('a', 'f');
            Console.WriteLine(interval.Match("text"));
        }
    }
}