using System;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args == null || args.Length == 0 || string.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("The program must be executed using text file containg a JSON string.");
            }

            string text = System.IO.File.ReadAllText(args[0]);

            var value = new Value();

            if (value.Match(text).Success())
            {
                Console.WriteLine("JSON is valid");
            }
            else
            {
                 Console.WriteLine("JSON is invalid");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}