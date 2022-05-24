namespace DecoratorPattern
{
    public interface ITextFile
    {
        string Adress { get; }

        void WriteToFile();

        string ReadFromFile();
    }
}
