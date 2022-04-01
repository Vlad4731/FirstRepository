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
            if (!string.IsNullOrEmpty(text))
            {
                foreach (var pattern in patterns)
                {
                    if (pattern.Match(text).Success())
                    {
                        return new SuccessMatch(pattern.Match(text).RemainingText());
                    }
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