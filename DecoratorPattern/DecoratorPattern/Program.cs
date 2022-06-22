using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace DecoratorPattern
{
    public class Program
    {
        public static readonly Func<string, string> Quoted = text => $"\"{text}\"";

        public static readonly Func<string, bool> Encrypt = text => text.StartsWith("encrypt=");
        public static readonly Func<string, bool> Decrypt = text => text.StartsWith("decrypt=");

        public static string Adress { get; set; } = @"C:\Users\Vlad\Documents\GitHub\FirstRepository\DecoratorPattern\DecoratorPattern\bin\Debug\netcoreapp3.1\test.txt";

        public static bool CheckReadWriteCommand(string x)
            => x == "read" || x == "write";

        public static bool CheckGzipCommand(string x)
            => x == "gzip";

        public static string ReturnPassword(string x, Func<string, bool> f)
        {
            if (f(x))
            {
                return x[(x.IndexOf("=") + 1) ..];
            }

            return "Command error.";
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

        private static FileStream CompressFile(FileStream fileStream)
        {
            using FileStream compressedFileStream = File.Create(Adress + ".zip");
            using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
            fileStream.CopyTo(compressor);
            fileStream = File.Open(Adress, FileMode.Open);
            return fileStream;
        }

        private static FileStream DecompressFile(FileStream fileStream)
        {
            using FileStream outputFileStream = File.Create(Adress + "_unzipped.txt");
            using var decompressor = new GZipStream(fileStream, CompressionMode.Decompress);
            decompressor.CopyTo(outputFileStream);
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

            Console.WriteLine(Quoted(args[0]) + " is not a valid path.");
        }

        static void Main(string[] args)
        {
            CheckAndPassAdress(args);
            using FileStream fileStream = File.Open(Adress, FileMode.Open);
        }
    }
}
