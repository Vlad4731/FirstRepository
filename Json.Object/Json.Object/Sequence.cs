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
            if (string.IsNullOrEmpty(text))
            {
                return new FailedMatch(text);
            }

            string backupText = text;

            foreach (var pattern in patterns)
            {
                if(string.IsNullOrEmpty(text))
                {
                    break;
                }

                if (!pattern.Match(text).Success())
                {
                    return new FailedMatch(backupText);
                }

                text = pattern.Match(text).RemainingText();
            }

            return new SuccessMatch(text);
        }

    }
}