using System;
using System.IO;
using System.Text;

namespace DecoratorPattern
{
    public class Program
    {
        public static string Adress { get; set; } = @"C:\Users\Vlad\Documents\GitHub\FirstRepository\DecoratorPattern\DecoratorPattern\bin\Debug\netcoreapp3.1\test.txt";

        static void Main()
        {
            using FileStream fileStream = File.Open(Adress, FileMode.Open);
            StreamReader readStream = new StreamReader(fileStream);
            readStream.ReadToEnd();
            readStream.Close();
        }
    }
}
