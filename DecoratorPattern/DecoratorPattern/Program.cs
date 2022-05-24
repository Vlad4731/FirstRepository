using System;

namespace DecoratorPattern
{
    public class Program
    {
        public static string Adress { get; set; } = @"C:\Users\Vlad\Documents\GitHub\FirstRepository\DecoratorPattern\DecoratorPattern\bin\Debug\netcoreapp3.1\test.txt";

        public static void FileManipulation(ITextFile text, string input)
        {
            Console.WriteLine("Type text to be printed to file.");

            switch (input)
            {
                case "1":
                    ITextFile encrypt = new EncryptDecorator(text);
                    encrypt.WriteToFile();
                    break;

                case "2":
                    ITextFile gzip = new GzipDecorator(text);
                    gzip.WriteToFile();
                    break;

                case "3":
                    ITextFile both = new GzipDecorator(text);
                    both = new EncryptDecorator(both);
                    both.WriteToFile();
                    break;

                default:
                    text.WriteToFile();
                    break;
            }
        }

        static void Main()
        {
            ITextFile textFile = new TextFile(Console.ReadLine());

            Console.WriteLine("Write 0 for plain text output, 1 for encrypted text, 2 for gzipped text and 3 for both encrypted and gzipped");

            FileManipulation(textFile, Console.ReadLine());
        }
    }
}
