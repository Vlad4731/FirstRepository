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
            string backupText = text;

            if (!string.IsNullOrEmpty(text))
            {
                foreach (var pattern in patterns)
                {
                    if (pattern.Match(text).Success())
                    {
                        text = pattern.Match(text).RemainingText();
                        return new SuccessMatch(text);
                    }
                }
            }

            return new FailedMatch(backupText);
        }

        public void Add(IPattern newPattern)
        {
            System.Array.Resize(ref patterns, patterns.Length + 1);
            patterns[^1] = newPattern;
        }
    }
}