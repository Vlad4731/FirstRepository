namespace Json
{
    public class Choice : IPattern
    {
        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in patterns)
            {
                IMatch match = pattern.Match(text);

                if (match.Success())
                {
                    return match;
                }
            }

            return new FailedMatch(text);
        }

        public void Add(IPattern newPattern)
        {
            System.Array.Resize(ref patterns, patterns.Length + 1);
            patterns[^1] = newPattern;
        }
    }
}