using System;
using System.IO;
using System.Text;

namespace DecoratorPattern
{
    public class Program
    {
        public static string Adress { get; set; } = @"C:\Users\Vlad\Documents\GitHub\FirstRepository\DecoratorPattern\DecoratorPattern\bin\Debug\netcoreapp3.1\test.txt";

        public static string ReadFromFile()
        {
            string fileText = "";

            using FileStream fileStream = File.OpenRead(Adress);
            byte[] bytes = new byte[1024];
            UTF8Encoding utf8 = new UTF8Encoding(true);
            while (fileStream.Read(bytes, 0, bytes.Length) > 0)
            {
               fileText += utf8.GetString(bytes);
            }

            fileStream.Close();

            return fileText;
        }

        public static void WriteToFile(string inputString)
        {
            using FileStream fileStream = File.OpenWrite(Adress);
            AddText(fileStream, inputString);
        }

        private static void AddText(FileStream fileStream, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fileStream.Write(info, 0, info.Length);
            fileStream.Close();
        }

        static void Main()
        {
            WriteToFile("Gazpacho");
            Console.WriteLine(ReadFromFile());
        }
    }
}
