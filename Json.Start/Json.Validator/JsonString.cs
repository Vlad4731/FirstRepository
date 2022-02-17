using System;

namespace Json
{
    public static class JsonString
    {
        public const int HEXLENGTH = 4;

        public static bool IsJsonString(string input)
        {
            return IsDoubleQuoted(input)
                && !ContainsControlCharacters(input)
                && ContainsValidEscapeCharacters(input);
        }

        static bool StringIsEmptyOrNull(string input)
        {
            return input == string.Empty || input == null;
        }

        static bool JsonHexIsValid(string input)
        {
            foreach (char c in input[1..])
            {
                if (!"0123456789abcdefABCDEF".Contains(c))
                {
                    return false;
                }
            }

            return true;
        }

        static bool ContainsValidEscapeCharacters(string input)
        {
            if (!@input.Contains('\\') ^ input.Contains("\\\\"))
            {
                return true;
            }

            return !EndsWithReverseSolidus(input)
                && ValidateEachEscapeCharacter(@input);
        }

        static bool ValidateEachEscapeCharacter(string input)
        {
            for (int i = 0; i < @input.Length - 1; i++)
            {
                if (input[i] == '\\' && !CheckForEscapeCharacterCodes(input[i + 1]))
                {
                    return false;
                }

                if (input[i] == '\\' && @input[i + 1] == 'u' && (i > @input.Length - HEXLENGTH || !JsonHexIsValid(@input.Substring(i + 1, HEXLENGTH + 1))))
                {
                    return false;
                }
            }

            return true;
        }

        static bool CheckForEscapeCharacterCodes(char input)
        {
            char[] array = { '/', '\"', 'b', 'f', 'n', 'u', 'r', 't' };

            foreach (char c in array)
            {
                if (input == c)
                {
                    return true;
                }
            }

            return false;
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
                if (c < '\u0020' || input.Contains(@"\u0022 ") || input.Contains(@"\u005c "))
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
