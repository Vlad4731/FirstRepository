using System;
using System.IO;

namespace DecoratorPattern
{
    public class Program
    {
        public static string Adress
        {
            get => @"C:\Users\Vlad\Documents\GitHub\FirstRepository\DecoratorPattern\DecoratorPattern\bin\Debug\netcoreapp3.1\test.txt";
            set => Adress = value;
        }

        static void Main()
        {
            Adress = Console.ReadLine();
            Console.WriteLine(File.ReadAllText(Adress));
        }
    }
}
