using System;

namespace Json
{
    public static class JsonString
    {
        private const int TWO = 2;

        public static bool IsJsonString(string input)
        {
            return IsDoubleQuoted(input);
        }

        static bool StringIsEmptyOrNull(string input)
        {
            return input == string.Empty || input == null;
        }

        static bool IsDoubleQuoted(string input)
        {
            if (StringIsEmptyOrNull(input))
            {
                return false;
            }

            return input.Length > 1
                && input[0] == '\"'
                && input[^1] == '\"'
                && CountOccurancesOfCharacter(input, '\"') >= TWO;
        }

        static int CountOccurancesOfCharacter(string input, char ch)
        {
            int count = 0;

            foreach (char c in input)
            {
                if (c == ch)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
