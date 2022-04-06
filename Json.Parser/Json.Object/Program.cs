using System;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args == null || args.Length == 0)
            {
                Console.WriteLine("The program must be executed using text file containg a JSON string.");
            }

            string text = System.IO.File.ReadAllText(args[0]);

            var value = new Value();
            IMatch match = value.Match(text);

            if (match.RemainingText() == "" && match.Success())
            {
                Console.WriteLine("JSON is valid");
            }
            else
            {
                 Console.WriteLine("JSON is invalid");
            }
        }
    }
}