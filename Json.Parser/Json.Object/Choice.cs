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
            if (string.IsNullOrEmpty(text))
            {
                return new FailedMatch(text);
            }

            string backupText = text;
            bool match = false;

            foreach (var pattern in patterns)
            {
                if (pattern.Match(text).Success())
                {
                    match = true;
                    text = pattern.Match(text).RemainingText();
                    break;
                }

            }

            return match == true
                ? new SuccessMatch(text)
                : new FailedMatch(backupText);
        }

        public void Add(IPattern newPattern)
        {
            System.Array.Resize(ref patterns, patterns.Length + 1);
            patterns[^1] = newPattern;
        }
    }
}