using System;
using System.IO;

namespace DecoratorPattern
{
    public static class Program
    {
        public static readonly Func<string, string> Quoted = text => $"\"{text}\"";

        public static readonly Func<string, bool> Encrypt = text => text.StartsWith("encrypt=");
        public static readonly Func<string, bool> Decrypt = text => text.StartsWith("decrypt=");
        public static readonly Func<string, bool> Read = text => text.ToLower() == "read";
        public static readonly Func<string, bool> Write = text => text.ToLower() == "write";
        public static readonly Func<string, bool> Gzip = text => text.ToLower() == "gzip";

        public static string Adress { get; set; } = @"C:\Users\Vlad\Documents\GitHub\FirstRepository\DecoratorPattern\DecoratorPattern\bin\Debug\netcoreapp3.1\test.txt";

        public static string ReturnPassword(string x, Func<string, bool> f)
        {
            if (f(x))
            {
                return x[(x.IndexOf("=") + 1) ..];
            }

            throw new ArgumentException($"{x} is not a valid command.");
        }

        public static FileStream ReadFromFile(FileStream fileStream)
        {
            StreamReader readStream = new StreamReader(fileStream);
            readStream.ReadToEnd();
            readStream.Close();
            fileStream = File.Open(Adress, FileMode.Open);
            return fileStream;
        }

        public static FileStream WriteToFile(FileStream fileStream)
        {
            StreamWriter writeStream = new StreamWriter(fileStream);
            writeStream.WriteLine("This is a test.");
            writeStream.Close();
            fileStream = File.Open(Adress, FileMode.Open);
            return fileStream;
        }

        private static void CheckAndPassAdress(string[] args)
        {
            if (args.Length < 1)
            {
                return;
            }

            if (args.Length >= 1 && File.Exists(args[0]))
            {
                Adress = args[0];
                return;
            }

            throw new ArgumentException(Quoted(args[0]) + " is not a valid path.");
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S109:Magic numbers should not be used", Justification = "args")]
        private static void ChooseService(string[] args)
            {
            using FileStream fileStream = File.Open(Adress, FileMode.Open);

            if (args.Length < 2)
            {
                throw new ArgumentException("Read/write command not found.");
            }

            if (args.Length >= 3 && !Gzip(args[3]))
            {
                return;
            }

            throw new ArgumentException("Read/write command not found.");
        }

        static void Main(string[] args)
        {
            CheckAndPassAdress(args);
        }
    }
}
