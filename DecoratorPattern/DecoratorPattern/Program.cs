using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace DecoratorPattern
{
    public class Program
    {
        public static string Adress { get; set; } = @"C:\Users\Vlad\Documents\GitHub\FirstRepository\DecoratorPattern\DecoratorPattern\bin\Debug\netcoreapp3.1\test.txt";

        public static void FileManipulation(string[] args)
        {
            FileStream fileStream;

            if (args.Length <= 1)
            {
                return;
            }

            Adress = args[0];

            if (args[1] == "0")
            {
                fileStream = File.OpenRead(Adress);
                Console.WriteLine(ReadFromFile(fileStream));
            }
            else if (args[1] == "1")
            {
                fileStream = File.OpenWrite(Adress);
                Console.WriteLine("Introduceti textul ce urmeaza a fi scris in fisier:");
                WriteToFile(fileStream, Console.ReadLine());
            }
        }

        public static string ReadFromFile(FileStream fileStream)
        {
            string fileText = "";

            byte[] bytes = new byte[1024];
            UTF8Encoding utf8 = new UTF8Encoding(true);
            while (fileStream.Read(bytes, 0, bytes.Length) > 0)
            {
               fileText += utf8.GetString(bytes);
            }

            fileStream.Close();

            return fileText;
        }

        public static void WriteToFile(FileStream fileStream, string inputString)
        {
            File.WriteAllText(Adress, string.Empty);
            AddText(fileStream, inputString);
        }

        private static void AddText(FileStream fileStream, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fileStream.Write(info, 0, info.Length);
            fileStream.Close();
        }

        private static void CompressFile(FileStream originalFileStream)
        {
            using FileStream compressedFileStream = File.Create(Adress + ".zip");
            using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
            originalFileStream.CopyTo(compressor);
        }

        private static void EncryptFile(FileStream originalFileStream)
        {
            using CryptoStream crypto = new CryptoStream(originalFileStream);
        }

        static void Main(string[] args)
        {
            FileManipulation(args);
        }
    }
}
