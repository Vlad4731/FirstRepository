using System;
using System.IO;

namespace DecoratorPattern
{
    internal class Program
    {
        public static string Adress { get; set; }

        static void Main()
        {
            Adress = Console.ReadLine();
            Console.WriteLine(File.ReadAllText(Adress));
        }
    }
}
