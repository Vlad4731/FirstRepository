using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return IsDoubleQuoted(input);
        }

        static bool IsDoubleQuoted(string input)
        {
            return input.Length > 1
                && input[0] == '\"'
                && input[^1] == '\"';
        }
    }
}
