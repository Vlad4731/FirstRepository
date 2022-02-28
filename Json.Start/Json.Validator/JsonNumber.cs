using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            int dotIndex = input.IndexOf('.');
            int exponentIndex = input.IndexOfAny("eE".ToCharArray());

            return IsValidIntegerNumber(ExtractIntegerPart(input, dotIndex, exponentIndex))
                && IsValidFractionalNumber(ExtractFractionalPart(input, dotIndex, exponentIndex))
                && IsValidExponentNumber(ExtractExponentialPart(input, exponentIndex));
        }

        static bool IsValidIntegerNumber(string input)
        {
            if (input.Length > 1 && input.StartsWith('0'))
            {
                return false;
            }

            if (input.StartsWith('-'))
            {
                input = input[1..];
            }

            return StringIsDigits(input);
        }

        static bool IsValidFractionalNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            return StringIsDigits(input[1..]);
        }

        static bool IsValidExponentNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            if (!input.StartsWith('e') && !input.StartsWith('E'))
            {
                return false;
            }

            input = input[1..];

            if (input.StartsWith('-') || input.StartsWith('+'))
            {
                input = input[1..];
            }

            return StringIsDigits(input);
        }

        static string ExtractIntegerPart(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex > -1)
            {
                return input[.. dotIndex];
            }

            if (exponentIndex > 1)
            {
                return input[.. exponentIndex];
            }

            return input;
        }

        static string ExtractFractionalPart(string input, int dotIndex, int exponentIndex)
        {
            if (exponentIndex > -1 && dotIndex > exponentIndex)
            {
                return null;
            }

            if (exponentIndex > -1 && dotIndex > -1)
            {
                return input[dotIndex.. (exponentIndex - 1)];
            }

            return dotIndex > -1 ? input[dotIndex..] : null;
        }

        static string ExtractExponentialPart(string input, int exponentIndex)
        {
            return exponentIndex > -1 ? input[exponentIndex..] : null;
        }

        static bool StringIsDigits(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return input.Length > 0;
        }
    }
}