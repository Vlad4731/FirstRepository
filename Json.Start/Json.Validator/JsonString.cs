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
            if (!@input.Contains('\\'))
            {
                return true;
            }

            return ValidateEachEscapeCharacter(@input);
        }

        static bool ValidateEachEscapeCharacter(string input)
        {
            for (int i = 1; i < @input.Length - 1; i++)
            {
                if (input[i] == '\\' && (!"\"/bfnurt\\".Contains(input[i + 1]) || i + 1 == input.Length - 1))
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

        static bool ContainsControlCharacters(string input)
        {
            foreach (char c in input)
            {
                if (c < '\u0020')
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
