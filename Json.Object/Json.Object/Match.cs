﻿namespace Json
{
    public class Match : IMatch
    {
        string text;

        public Match (string match)
        {
            text = match;
        }

        public bool Success()
        {
            return true;
        }

        public string RemainingText()
        {
            return text;
        }

    }
}