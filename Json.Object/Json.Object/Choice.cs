﻿
namespace Json
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

            foreach (var pattern in patterns)
            {
                if(pattern.Match(text))
                {
                    return true;
                }
            }

            return false;
        }
    }
}