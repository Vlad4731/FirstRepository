namespace Json
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            string backupText = text;

            foreach (var pattern in patterns)
            {
                IMatch match = pattern.Match(text);

                if (!match.Success())
                {
                    return new FailedMatch(backupText);
                }

                text = match.RemainingText();
            }

            return new SuccessMatch(text);
        }

    }
}