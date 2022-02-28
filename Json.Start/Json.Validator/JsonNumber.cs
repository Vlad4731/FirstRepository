using System;

namespace Json
{
    struct Number
    {
        public string Whole;
        public string Fraction;
        public string Exponent;

        public Number(string integer, string fraction, string exponent)
        {
            Integer = integer;
            Fraction = fraction;
            Exponent = exponent;
        }
    }

    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input) || EndsWithUnfinishedFractionOrExponential(input))
            {
                return false;
            }

            Number number = SplitNumber(input);

            return IsValidWIntegerNumber(number.Whole)
                && IsValidFractionalNumber(number.Fraction)
                && IsValidExponentNumber(number.Exponent);
        }

        static bool EndsWithUnfinishedFractionOrExponential(string input)
        {
            return input.EndsWith('.') || input.EndsWith('e') || input.EndsWith('E');
        }

        static bool IsValidIntegerNumber(string input)
        {
            if (input.Length > 1 && input.StartsWith('0'))
            {
                return false;
            }

            if (StringStartsWithValidSymbol(input))
            {
                return StringIsDigits(input[1..]);
            }

            return StringIsDigits(input);
        }

        static bool IsValidFractionalNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            return StringIsDigits(input);
        }

        static bool IsValidExponentNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            return IsValidIntegerNumber(input);
        }

        static Number SplitNumber(string input)
        {
            return new Number
            {
                Whole = ExtractWholePart(input),
                Fraction = ExtractFractionalPart(input),
                Exponent = ExtractExponentialPart(input)
            };
        }

        static string ExtractWholePart(string input)
        {
            if (input.Contains('.', StringComparison.CurrentCultureIgnoreCase))
            {
                return input.Substring(0, input.IndexOf('.'));
            }

            if (input.Contains('e', StringComparison.CurrentCultureIgnoreCase))
            {
                return input.Substring(0, input.IndexOf('e', StringComparison.CurrentCultureIgnoreCase));
            }

            return input;
        }

        static string ExtractExponentialPart(string input)
        {
            return input.Contains('e', StringComparison.CurrentCultureIgnoreCase)
                ? "" + input.Substring(input.IndexOf('e', StringComparison.CurrentCultureIgnoreCase) + 1)
                : null;
        }

        static string ExtractFractionalPart(string input)
        {
            if (input.Contains('e', StringComparison.InvariantCultureIgnoreCase)
                && input.IndexOf('.') > input.IndexOf('e', StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            if (input.Contains('e', StringComparison.CurrentCultureIgnoreCase))
            {
                return "" + input.Substring(
                    input.IndexOf('.', StringComparison.CurrentCultureIgnoreCase) + 1,
                    input.IndexOf('e', StringComparison.CurrentCultureIgnoreCase) - input.IndexOf('.') - 1);
            }

            return input.Contains('.') ? "" + input.Substring(input.IndexOf('.', StringComparison.CurrentCultureIgnoreCase) + 1) : null;
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

            return true;
        }

        static bool StringStartsWithValidSymbol(string input)
        {
            if (input.Length <= 1)
            {
                return false;
            }

            return input.StartsWith('-') ^ input.StartsWith('+');
        }
    }
}