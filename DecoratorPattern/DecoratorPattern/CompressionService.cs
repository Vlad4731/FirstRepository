using System;
using System.IO;
using System.IO.Compression;

namespace DecoratorPattern
{
    internal static class CompressionService
    {
        private static FileStream CompressFile(FileStream fileStream, string adress)
        {
            using FileStream compressedFileStream = File.Create(adress + ".zip");
            using var compressor = new System.IO.Compression.GZipStream(compressedFileStream, CompressionMode.Compress);
            fileStream.CopyTo(compressor);
            fileStream = File.Open(adress, FileMode.Open);
            return fileStream;
        }

        private static FileStream DecompressFile(FileStream fileStream, string adress)
        {
            using FileStream outputFileStream = File.Create(adress + "_unzipped.txt");
            using var decompressor = new GZipStream(fileStream, CompressionMode.Decompress);
            decompressor.CopyTo(outputFileStream);
            fileStream = File.Open(adress, FileMode.Open);
            return fileStream;
        }
    }
}