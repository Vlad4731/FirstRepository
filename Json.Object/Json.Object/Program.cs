using System;

namespace Json.Object
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