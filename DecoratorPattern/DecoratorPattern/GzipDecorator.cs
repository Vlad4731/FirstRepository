using System.IO;
using System.IO.Compression;

namespace DecoratorPattern
{
    internal class GzipDecorator : TextFileDecorator
    {
        public GzipDecorator(ITextFile textFile) : base(textFile)
        {
        }

        public override void WriteToFile() => CompressFile();

        private void CompressFile()
        {
            base.WriteToFile();
            using FileStream originalFileStream = File.Open(Adress, FileMode.Open);
            using FileStream compressedFileStream = File.Create(Adress + ".zip");
            using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
            originalFileStream.CopyTo(compressor);
        }
    }
}
