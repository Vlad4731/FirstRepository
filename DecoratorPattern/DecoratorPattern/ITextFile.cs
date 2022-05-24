namespace DecoratorPattern
{
    interface ITextFile
    {
        string Adress { get; }

        void WriteToFile();

        string ReadFromFile();
    }
}
