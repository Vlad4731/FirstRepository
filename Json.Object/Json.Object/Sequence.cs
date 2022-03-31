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

            string matchedText = "";

            foreach (var pattern in patterns)
            {
                if (!pattern.Match(text).Success())
                {
                    return new FailedMatch(matchedText + text);
                }

                matchedText += text[0..^(text.Length - 1)];
                text = pattern.Match(text).RemainingText();
            }

            return new SuccessMatch(text);
        }

    }
}