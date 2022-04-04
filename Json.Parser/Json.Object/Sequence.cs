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

            (string, bool) match;

            foreach (var pattern in patterns)
            {
                match = (pattern.Match(text).RemainingText(), pattern.Match(text).Success());

                if (!match.Item2)
                {
                    return new FailedMatch(backupText);
                }

                text = match.Item1;
            }

            return new SuccessMatch(text);
        }

    }
}