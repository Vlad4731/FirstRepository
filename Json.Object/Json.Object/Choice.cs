﻿namespace Json
{
    public class Choice : IPattern
    {
        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            foreach(char c in text)
            {
                foreach (var pattern in patterns)
                {
                    if (pattern.Match(c.ToString()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}