using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsValidIntNumber(input) || IsValidDoubleNumber(input);
        }

        public static bool IsValidIntNumber(string input)
        {
            return int.TryParse(input, out _) && input.IndexOf("0") == input.Length - 1 ^ input.IndexOf("0") == -1;
        }

        public static bool IsValidDoubleNumber(string input)
        {
            return double.TryParse(input, out _)
                && (NumberContainsValidFractionalDot(input)
                && !StringContainsLettersOtherThanExponent(input)
                || NumberContainsExponent(input));
        }

        public static bool NumberContainsExponent(string input)
        {
            return (input.Contains('e') && CharacterAppearsOnlyOnce(input, 'e'))
                ^ (input.Contains('E') && CharacterAppearsOnlyOnce(input, 'E'));
        }

        public static bool CharacterAppearsOnlyOnce(string input, char character)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c == character)
                {
                    count++;
                }
            }

            return count == 1;
        }

        public static bool NumberIsBetween(int index, int min, int max)
        {
            return index > min && index < max;
        }

        public static bool StringContainsLettersOtherThanExponent(string input)
        {
            return StringContainsCapitalLetters(input) || StringContainsSmallLetters(input) && !NumberContainsExponent(input);
        }

        static bool StringContainsSmallLetters(string input)
        {
            foreach (char c in input)
            {
                if (c >= 'a' && c <= 'z')
                {
                    return true;
                }
            }

            return false;
        }

        static bool StringContainsCapitalLetters(string input)
        {
            foreach (char c in input)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    return true;
                }
            }

            return false;
        }

        static bool NumberContainsValidFractionalDot(string input)
        {
            return NumberIsBetween(input.IndexOf("."), -1, input.Length - 1)
                && CharacterAppearsOnlyOnce(input, '.');
        }
    }
}