using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
         {
            if (int.TryParse(input, out _))
            {
                return input.IndexOf("0") == input.Length - 1 ^ input.IndexOf("0") == -1;
            }

            if (!double.TryParse(input, out _))
            {
                return false;
            }

            return input.IndexOf(".") > -1 && input.IndexOf(".") < input.Length - 1;
        }
    }
}
