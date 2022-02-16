using System;

namespace Json
{
    public static class JsonString
    {
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
            const int LENGTH_OF_HEXCODE = 5;

            if (!@input.Contains(@"\u"))
            {
                return false;
            }

            return @input[@input.IndexOf('u') ..].Length < LENGTH_OF_HEXCODE + 1;
        }

        static bool ContainsValidEscapeCharacters(string input)
        {
            if (!input.Contains('\\'))
            {
                return true;
            }

            return !EndsWithReverseSolidus(input)
                && "\" \\ \u002f bfnrtu".Contains(input[input.IndexOf('\\') + 1]);
        }

        static bool EndsWithReverseSolidus(string input)
        {
            const int offset_of_last_character_in_string = 2;

            return input[^offset_of_last_character_in_string] == '\\';
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
                && input[^1] == '\"';
        }
    }
}
