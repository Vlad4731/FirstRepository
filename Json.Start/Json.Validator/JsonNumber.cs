using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsValidIntNumber(input) || IsValidDoubleNumber(input);
        }

        static bool IsValidIntNumber(string input)
        {
            return int.TryParse(input, out _) && input.IndexOf("0") == input.Length - 1 ^ input.IndexOf("0") == -1;
        }

        static bool IsValidDoubleNumber(string input)
        {
            return double.TryParse(input, out _)
                && NumberIsBetween(input.IndexOf("."), -1, input.Length - 1)
                && CountCharacterInString(input, '.') == 1;
        }

        static int CountCharacterInString(string input, char character)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c == character)
                {
                    count++;
                }
            }

            return count;
        }

        static bool NumberIsBetween(int index, int min, int max)
        {
            return index > min && index < max;
        }
    }
}
