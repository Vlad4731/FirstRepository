using System;

namespace Json
{
    public static class JsonString
    {
        private const int HexLength = 5;

        public static bool IsJsonString(string input)
        {
            return IsDoubleQuoted(input)
                && !ContainsControlCharacters(input)
                && ContainsValidEscapeCharacters(input)
                && !EndsWithUnfinishedHexNumber(input);
        }

        static bool StringIsEmptyOrNull(string input)
        {
            return input == string.Empty || input == null;
        }

        static bool EndsWithUnfinishedHexNumber(string @input)
        {
            if (!@input.Contains(@"\u"))
            {
                return false;
            }

            return @input.Substring(@input.IndexOf('u')).Length < HexLength + 1;
        }

        static bool ContainsValidEscapeCharacters(string input)
        {
            if (!input.Contains('\\'))
            {
                return true;
            }

            return input.IndexOf('\\') != input.Length - 1 - 1
                && "\" \\ \u002f bfnrtu".Contains(input[input.IndexOf('\\') + 1]);
        }

        static bool ContainsControlCharacters(string input)
        {
            foreach (char c in input)
            {
                if (c < '\u0020' || (c > '\u007f' && c < '\u009f'))
                {
                    return true;
                }
            }

            return false;
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
                && CountOccurancesOfCharacter(input, '\"') > 1;
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
