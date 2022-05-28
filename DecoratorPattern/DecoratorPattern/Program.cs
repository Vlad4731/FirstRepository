using System;
using System.IO;
using System.IO.Compression;
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
                fileStream = File.Open(Adress, FileMode.Open);
                Console.WriteLine("Introduceti textul ce urmeaza a fi scris in fisier:");

                if (args[2] == "1")
                {
                    CompressFile(WriteToFile(fileStream, Console.ReadLine()));
                    return;
                }

                if (args[2] == "2")
                {
                    Encrypt(WriteToFile(fileStream, Console.ReadLine()));
                    return;
                }

                if (args[2] == "3")
                {
                    CompressFile(Encrypt(WriteToFile(fileStream, Console.ReadLine())));
                    return;
                }

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

        public static FileStream WriteToFile(FileStream fileStream, string inputString)
        {
            using StreamWriter writeFile = new StreamWriter(fileStream);
            writeFile.WriteLine(inputString);
            return fileStream;
        }

        private static FileStream CompressFile(FileStream originalFileStream)
        {
            originalFileStream = File.Open(Adress, FileMode.Open);
            using FileStream compressedFileStream = File.Create(Adress + ".zip");
            using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
            originalFileStream.CopyTo(compressor);

            return originalFileStream;
        }

        public static FileStream Encrypt(FileStream fileStream)
        {
            File.Encrypt(Adress);

            return fileStream;
        }

        static void Main(string[] args)
        {
            FileManipulation(args);
        }
    }
}
