using System;
using System.IO;

namespace DecoratorPattern
{
    public class Program
    {
        public static string Adress { get; set; } = @"C:\Users\Vlad\Documents\GitHub\FirstRepository\DecoratorPattern\DecoratorPattern\bin\Debug\netcoreapp3.1\test.txt";

        static void Main()
        {
            TextFile textFile = new TextFile(Adress);
            EncryptDecorator encrypt = new EncryptDecorator(textFile);
            encrypt.WriteToFile();
        }
    }
}
