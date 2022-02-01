using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return (int.TryParse(input, out _) && input.IndexOf("0") == input.Length - 1 ^ input.IndexOf("0") == -1) || (double.TryParse(input, out _) && input.Contains("."));
        }
    }
}
