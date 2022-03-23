﻿namespace Json
{
    public class Range
    {
        private char starChar;
        private char endChar;

        public Range(char start, char end)
        {
            starChar = start;
            endChar = end;
        }

        public bool Match(string text)
        {
            foreach(char c in text)
            {
                if (c < starChar || c > endChar)
                {
                    return false;
                }
            }

            return true;
        }
    }
}