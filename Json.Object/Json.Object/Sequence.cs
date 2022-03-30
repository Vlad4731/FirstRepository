namespace Json
{
    public class Sequence : IPattern
    {
        IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new FailedMatch(text);
            }

            string textBackup = text;

            foreach (var pattern in patterns)
            {
                if (!pattern.Match(text).Success())
                {
                    return new FailedMatch(textBackup);
                }

                text = pattern.Match(text).RemainingText();
            }

            return new SuccessMatch(text);
        }

    }
}